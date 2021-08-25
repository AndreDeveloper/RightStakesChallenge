using Quartz;
using RightStakes.Challenge.Services.Crawler.Interfaces;
using System.Threading.Tasks;

namespace RightStakes.Challenge.Services.Crawler.Jobs
{
    [DisallowConcurrentExecution]
    public class CryptoCurrencyApiCrawlerJob : IJob
    {
        private readonly ICoingeckoService _service;

        public CryptoCurrencyApiCrawlerJob(ICoingeckoService service)
        {
            _service = service;
        }

        public async Task Execute(IJobExecutionContext context)
        {

            var cryptoCurrencies = await _service.GetCryptoCurrencies();


        }
    }
}
