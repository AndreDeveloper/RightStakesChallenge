using AutoMapper;
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
    public class CryptoCurrencyApiCrawlerJob : IJob
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IServiceProvider _serviceProvider;


        public CryptoCurrencyApiCrawlerJob(IMapper mapper, IConfiguration configuration, IServiceProvider serviceProvider)
        {
            _mapper = mapper;
            _configuration = configuration;
            _serviceProvider = serviceProvider;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            using (var service = CoingeckoService.CoingeckoServiceFactory.Create(_configuration))
            {
                try
                {
                    using (var persistingCryptoCurrencyProcess = PersistingCryptoCurrencyProcessBusiness.PersistingCryptoCurrencyProcessBusinessFactory.Create(CryptoCurrencyRepository.CryptoCurrencyRepositoryFactory.Create(_configuration), _serviceProvider))
                    {
                        var cryptoCurrencies = await service.GetCryptoCurrencies();

                        if (cryptoCurrencies != null)
                        {
                            foreach (var cryptoCurrencie in cryptoCurrencies)
                            {
                                persistingCryptoCurrencyProcess.Persist(_mapper.Map<CryptoCurrency>(cryptoCurrencie));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    //TODO: some log
                }
            }
        }
    }
}
