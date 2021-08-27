using Microsoft.Extensions.Configuration;
using Quartz;
using RightStakes.Challenge.Domain.Business;
using RightStakes.Challenge.Domain.Entities;
using RightStakes.Challenge.Infra.Data.Repository;
using RightStakes.Challenge.Services.Crawler.Services;
using System;
using System.Threading.Tasks;

namespace RightStakes.Challenge.Services.Crawler.Jobs
{
    [DisallowConcurrentExecution]
    public class CurrencyConvertionApiCrawlerJob : IJob
    {
        private readonly IConfiguration _configuration;
        private readonly IServiceProvider _serviceProvider;

        public CurrencyConvertionApiCrawlerJob(IConfiguration configuration, IServiceProvider serviceProvider)
        {
            _configuration = configuration;
            _serviceProvider = serviceProvider;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                using (var service = CurrencyLayerService.CurrencyLayerServiceFactory.Create(_configuration))
                {
                    using (var persistingQuoteProcessBusiness = PersistingQuoteProcessBusiness.PersistingQuoteProcessBusinessFactory.Create(QuoteRepository.QuoteRepositoryFactory.Create(_configuration), _serviceProvider))
                    {
                        var currencyConvertion = await service.GetConvertionsFromUSD();

                        foreach (var item in currencyConvertion.Quotes)
                        {
                            persistingQuoteProcessBusiness.Persist(new Quote(item.Key, item.Value));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //TODO: do some log
            }
        }
    }
}
