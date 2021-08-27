using RightStakes.Challenge.Services.Crawler.Models;
using System;
using System.Threading.Tasks;

namespace RightStakes.Challenge.Services.Crawler.Interfaces
{
    public interface ICurrencyLayerService : IDisposable
    {
        Task<CurrencyConvertionModel> GetConvertionsFromUSD();
    }
}
