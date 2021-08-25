using Quartz;
using RightStakes.Challenge.Services.Crawler.Interfaces;
using System.Threading.Tasks;

namespace RightStakes.Challenge.Services.Crawler.Jobs
{
    [DisallowConcurrentExecution]
    public class CurrencyConvertionApiCrawlerJob : IJob
    {
        private readonly ICurrencyLayerService _service;

        public CurrencyConvertionApiCrawlerJob(ICurrencyLayerService service)
        {
            _service = service;

        }
        public async Task Execute(IJobExecutionContext context)
        {
            var a = await _service.GetConvertionsFromUSD();

            var b = 1;
            //return Task.FromResult(1);
        }
    }
}
