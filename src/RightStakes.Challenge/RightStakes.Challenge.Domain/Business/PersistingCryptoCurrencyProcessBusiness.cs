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
    public class PersistingCryptoCurrencyProcessBusiness : IPersistingCryptoCurrencyProcessBusiness
    {
        private readonly ICryptoCurrencyRepository _repository;
        private readonly IMemoryCache _cache;
        private int _cacheExpirationTimeInMinutes;
        private readonly IMediator _mediator;

        public PersistingCryptoCurrencyProcessBusiness(
            ICryptoCurrencyRepository repository,
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

        public void Persist(CryptoCurrency cryptoCurrency)
        {
            var persistedCriptoCurrency =
                _cache.GetOrCreate(cryptoCurrency.Id, entry =>
                {
                    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(_cacheExpirationTimeInMinutes);
                    entry.SetPriority(CacheItemPriority.High);

                    return _repository.GetBy(_ => _.Id == cryptoCurrency.Id);
                });

            if (persistedCriptoCurrency != null && persistedCriptoCurrency.HasChanged(cryptoCurrency))
            {
                //Persist changes in the datasabe
                persistedCriptoCurrency.Update(cryptoCurrency);
                _repository.Update(persistedCriptoCurrency);

                //Raise event
                _mediator.Publish(new CryptoCurrencyChangedNotification(persistedCriptoCurrency));
            }
            else if (persistedCriptoCurrency == null)
            {
                _repository.Add(cryptoCurrency);
                //Raise event
                _mediator.Publish(new CryptoCurrencyChangedNotification(cryptoCurrency));
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public static class PersistingCryptoCurrencyProcessBusinessFactory
        {
            public static PersistingCryptoCurrencyProcessBusiness Create(ICryptoCurrencyRepository repository, IServiceProvider provider)
            {
                return new PersistingCryptoCurrencyProcessBusiness(
                    repository,
                    provider.GetService(typeof(IMemoryCache)) as IMemoryCache,
                    provider.GetService(typeof(IMediator)) as IMediator,
                    provider.GetService(typeof(IConfiguration)) as IConfiguration);
            }
        }
    }
}
