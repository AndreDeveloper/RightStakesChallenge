using Microsoft.Extensions.Configuration;
using RightStakes.Challenge.Domain.Entities;
using RightStakes.Challenge.Domain.Interfaces.Repositories;
using RightStakes.Challenge.Infra.Data.Context;
using System.Collections.Generic;

namespace RightStakes.Challenge.Infra.Data.Repository
{
    public class CryptoCurrencyRepository : Repository<CryptoCurrency>, ICryptoCurrencyRepository
    {
        public CryptoCurrencyRepository(RightStakesContext context) : base(context)
        {

        }

        public void AddOrUpdate(List<CryptoCurrency> list)
        {
            if (list == null || list.Count == 0) return;

            foreach (var item in list)
            {
                if (Any(_ => _.Currency == item.Currency && _.Symbol == item.Symbol))
                {
                    var persisted = GetBy(_ => _.Currency == item.Currency && _.Symbol == item.Symbol);
                    if (persisted.HasChanged(item))
                    {
                        persisted.Update(item);
                        Update(item);
                    }
                }
                else
                {
                    Add(item);
                }
            }
        }

        public static class CryptoCurrencyRepositoryFactory
        {
            public static CryptoCurrencyRepository Create(IConfiguration configuration)
            {
                return new CryptoCurrencyRepository(RightStakesContext.RightStakesContextFactory.Create(configuration));
            }
        }
    }
}
