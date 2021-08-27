using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using RightStakes.Challenge.Domain.Entities;
using RightStakes.Challenge.Domain.Interfaces.Repositories;
using RightStakes.Challenge.Services.Crawler.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RightStakes.Challenge.Services.WebAPI.Controllers
{
    [ApiController]
    public class CryptoCurrencyController : ApiController
    {
        private readonly IMemoryCache _cache;
        private readonly ICryptoCurrencyRepository _repository;
        private readonly ICoingeckoService _coingeckoService;
        private readonly IMapper _mapper;

        public CryptoCurrencyController(
            IMemoryCache cache,
            ICryptoCurrencyRepository repository,
            ICoingeckoService coingeckoService,
            IMapper mapper
            )
        {
            _cache = cache;
            _repository = repository;
            _coingeckoService = coingeckoService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("cryptocurrencies/{currency}")]
        public async Task<IActionResult> Get(string currency = "USD")
        {
            //Firt check cache
            var result = _cache.Get<List<CryptoCurrency>>($"cryptocurrencies_{currency}");

            if (result != null) return Response(result);

            //Then check dataBase
            result = _repository.GetAllBy(_ => _.Currency == currency).ToList();

            if (result.Count() > 0)
            {
                _cache.Set<List<CryptoCurrency>>($"cryptocurrencies_{currency}", result);
                return Response(result);
            }

            //then check service
            var currencies = await _coingeckoService.GetCryptoCurrencies(currency);

            if (currencies != null && currencies.Count() > 0)
            {
                result = currencies.Select(_ =>
                {
                    var item = _mapper.Map<CryptoCurrency>(_);
                    item.SetCurrency(currency);
                    return item;
                }).ToList();

                _cache.Set<List<CryptoCurrency>>($"cryptocurrencies_{currency}", result);

                _repository.AddOrUpdate(result);
                return Response(result);
            }

            return BadRequest(new
            {
                success = false,
                error = "Currency not found"
            });
        }
    }
}