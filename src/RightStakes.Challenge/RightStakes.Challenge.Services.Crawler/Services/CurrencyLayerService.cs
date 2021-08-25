using Microsoft.Extensions.Configuration;
using Polly;
using Polly.Retry;
using RestSharp;
using RightStakes.Challenge.Services.Crawler.Interfaces;
using RightStakes.Challenge.Services.Crawler.Models;
using System;
using System.Threading.Tasks;

namespace RightStakes.Challenge.Services.Crawler.Services
{
    public class CurrencyLayerService : ICurrencyLayerService
    {
        private string _apiUri;
        private string _apiToken;
        private readonly RestClient _client;
        private readonly AsyncRetryPolicy _asyncPolicy;

        public CurrencyLayerService(IConfiguration configuration)
        {
            _apiUri = configuration.GetSection("currencyConvertionApiUri").Value;
            _apiToken = configuration.GetSection("currencyConvertionApiToken").Value;
            _client = new RestClient(_apiUri);

            var retryCount = Convert.ToInt32(configuration.GetSection("pollyRetryCount").Value);
            var retryAttempts = Convert.ToInt32(configuration.GetSection("pollyRetryAtempts").Value);
            _asyncPolicy = Policy
                .Handle<Exception>()
                .WaitAndRetryAsync(retryCount, retryAttemp => TimeSpan.FromSeconds(Math.Pow(2, retryAttempts)));
        }

        public async Task<CurrencyConvertionModel> GetConvertionsFromUSD()
        {
            return await _asyncPolicy.ExecuteAsync(async () =>
            {
                var request = new RestRequest($"live?access_key={_apiToken}&source=USD");
                return await _client.GetAsync<CurrencyConvertionModel>(request);
            });
        }
    }
}
