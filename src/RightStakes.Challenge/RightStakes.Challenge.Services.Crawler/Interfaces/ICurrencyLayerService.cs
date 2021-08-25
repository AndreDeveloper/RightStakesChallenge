using RightStakes.Challenge.Services.Crawler.Models;
using System.Threading.Tasks;

namespace RightStakes.Challenge.Services.Crawler.Interfaces
{
    public interface ICurrencyLayerService
    {
        Task<CurrencyConvertionModel> GetConvertionsFromUSD();
    }
}
