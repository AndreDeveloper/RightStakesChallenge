using RightStakes.Challenge.Domain.Entities;
using System;

namespace RightStakes.Challenge.Domain.Interfaces.Business
{
    public interface IPersistingQuoteProcessBusiness : IDisposable
    {
        void Persist(Quote quote);
    }
}
