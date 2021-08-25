using Microsoft.Extensions.Configuration;
using Polly;
using Polly.Retry;
using RestSharp;
using RightStakes.Challenge.Services.Crawler.Interfaces;
using RightStakes.Challenge.Services.Crawler.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RightStakes.Challenge.Services.Crawler.Services
{
    public class CoingeckoService : ICoingeckoService
    {
        private string _apiUri;
        private readonly RestClient _client;
        private readonly AsyncRetryPolicy _asyncPolicy;

        public CoingeckoService(IConfiguration configuration)
        {
            _apiUri = configuration.GetSection("coingeckoApiUri").Value;
            _client = new RestClient(_apiUri);

            var retryCount = Convert.ToInt32(configuration.GetSection("pollyRetryCount").Value);
            var retryAttempts = Convert.ToInt32(configuration.GetSection("pollyRetryAtempts").Value);
            _asyncPolicy = Policy
                .Handle<Exception>()
                .WaitAndRetryAsync(retryCount, retryAttemp => TimeSpan.FromSeconds(Math.Pow(2, retryAttempts)));
        }

        public async Task<IEnumerable<CryptoCurrencyModel>> GetCryptoCurrencies(string currency = "USD")
        {
            return await _asyncPolicy.ExecuteAsync(async () =>
            {
                var request = new RestRequest($"coins/markets?vs_currency={currency}");
                return await _client.GetAsync<List<CryptoCurrencyModel>>(request);
            });
        }
    }
}
