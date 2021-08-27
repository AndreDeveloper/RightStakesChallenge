using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using RightStakes.Challenge.Domain.Entities;
using RightStakes.Challenge.Domain.Interfaces.Business;
using RightStakes.Challenge.Domain.Interfaces.Repositories;
using RightStakes.Challenge.Domain.Notifications;
using System;

namespace RightStakes.Challenge.Domain.Business
{
    public class PersistingQuoteProcessBusiness : IPersistingQuoteProcessBusiness
    {
        private readonly IQuoteRepository _repository;
        private readonly IMemoryCache _cache;
        private int _cacheExpirationTimeInMinutes;
        private readonly IMediator _mediator;

        public PersistingQuoteProcessBusiness(
            IQuoteRepository repository,
            IMemoryCache cache,
            IMediator mediator,
            IConfiguration configuration
            )
        {
            _repository = repository;
            _cache = cache;
            _mediator = mediator;
            _cacheExpirationTimeInMinutes = Convert.ToInt32(configuration.GetSection("cacheExpirationTimeInMinutes").Value);
        }
        public void Persist(Quote quote)
        {
            var persistedQuote =
                _cache.GetOrCreate(quote.Name, entry =>
                {
                    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(_cacheExpirationTimeInMinutes);
                    entry.SetPriority(CacheItemPriority.High);

                    return _repository.GetBy(_ => _.Name == quote.Name);
                });

            if (persistedQuote != null && persistedQuote.HasChanged(quote))
            {
                //Persist changes in the datasabe
                persistedQuote.Update(quote.Value);
                _repository.Update(persistedQuote);

                //Raise event
                _mediator.Publish(new QuoteChangedNotification(persistedQuote));
            }
            else if (persistedQuote == null)
            {
                _repository.Add(quote);
                //Raise event
                _mediator.Publish(new QuoteChangedNotification(quote));
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public static class PersistingQuoteProcessBusinessFactory
        {
            public static PersistingQuoteProcessBusiness Create(IQuoteRepository repository, IServiceProvider serviceProvider)
            {
                return new PersistingQuoteProcessBusiness(
                            repository,
                            serviceProvider.GetService(typeof(IMemoryCache)) as IMemoryCache,
                            serviceProvider.GetService(typeof(IMediator)) as IMediator,
                            serviceProvider.GetService(typeof(IConfiguration)) as IConfiguration

                    );
            }
        }
    }
}
