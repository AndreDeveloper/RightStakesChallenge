using RightStakes.Challenge.Services.Crawler.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RightStakes.Challenge.Services.Crawler.Interfaces
{
    public interface ICoingeckoService
    {
        Task<IEnumerable<CryptoCurrencyModel>> GetCryptoCurrencies(string currency = "USD");
    }
}
