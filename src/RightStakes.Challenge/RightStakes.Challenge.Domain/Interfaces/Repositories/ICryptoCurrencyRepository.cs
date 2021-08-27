using RightStakes.Challenge.Domain.Entities;
using System.Collections.Generic;

namespace RightStakes.Challenge.Domain.Interfaces.Repositories
{
    public interface ICryptoCurrencyRepository : IRepository<CryptoCurrency>
    {
        void AddOrUpdate(List<CryptoCurrency> list);
    }
}
