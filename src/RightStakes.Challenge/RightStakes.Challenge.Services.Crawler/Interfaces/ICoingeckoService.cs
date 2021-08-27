using RightStakes.Challenge.Services.Crawler.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RightStakes.Challenge.Services.Crawler.Interfaces
{
    public interface ICoingeckoService : IDisposable
    {
        Task<IEnumerable<CryptoCurrencyModel>> GetCryptoCurrencies(string currency = "USD");
    }
}
