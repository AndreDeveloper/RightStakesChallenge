using RightStakes.Challenge.Domain.Entities;
using System.Collections.Generic;

namespace RightStakes.Challenge.Domain.Interfaces.Repositories
{
    public interface IQuoteRepository : IRepository<Quote>
    {
        void AddOrUpdate(List<Quote> list);
    }
}
