using Microsoft.Extensions.Configuration;
using RightStakes.Challenge.Domain.Entities;
using RightStakes.Challenge.Domain.Interfaces.Repositories;
using RightStakes.Challenge.Infra.Data.Context;
using System.Collections.Generic;

namespace RightStakes.Challenge.Infra.Data.Repository
{
    public class QuoteRepository : Repository<Quote>, IQuoteRepository
    {
        public QuoteRepository(RightStakesContext context) : base(context)
        {

        }

        public void AddOrUpdate(List<Quote> list)
        {
            if (list == null || list.Count == 0) return;

            foreach (var item in list)
            {
                if (Any(_ => _.Name == item.Name))
                {
                    var persisted = GetBy(_ => _.Name == item.Name);
                    if (persisted.HasChanged(item))
                    {
                        persisted.Update(item.Value);
                        Update(item);
                    }
                }
                else
                {
                    Add(item);
                }
            }
        }

        public static class QuoteRepositoryFactory
        {
            public static QuoteRepository Create(IConfiguration configuration)
            {
                return new QuoteRepository(RightStakesContext.RightStakesContextFactory.Create(configuration));
            }
        }
    }
}
