using RightStakes.Challenge.Domain.Entities;
using System;

namespace RightStakes.Challenge.Domain.Interfaces.Business
{
    public interface IPersistingCryptoCurrencyProcessBusiness : IDisposable
    {
        void Persist(CryptoCurrency cryptoCurrency);
    }
}
