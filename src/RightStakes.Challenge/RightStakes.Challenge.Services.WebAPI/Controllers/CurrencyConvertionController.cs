using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using RightStakes.Challenge.Domain.Entities;
using RightStakes.Challenge.Domain.Interfaces.Repositories;
using RightStakes.Challenge.Services.Crawler.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace RightStakes.Challenge.Services.WebAPI.Controllers
{
    [ApiController]
    public class CurrencyConvertionController : ApiController
    {
        private readonly IMemoryCache _cache;
        private readonly IQuoteRepository _repository;
        private readonly ICurrencyLayerService _currencyLayerService;
        private readonly IMapper _mapper;

        public CurrencyConvertionController(
            IMemoryCache cache,
            IQuoteRepository repository,
            ICurrencyLayerService currencyLayerService,
            IMapper mapper
            )
        {
            _cache = cache;
            _repository = repository;
            _currencyLayerService = currencyLayerService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("currencyconvertion/fromusd/{currency}")]
        public async Task<IActionResult> Get(string currency)
        {
            //Firt check cache
            currency = currency.ToUpper();
            var result = _cache.Get<Quote>($"quote_{currency}");
            var conversion = $"USD{currency}";

            if (result != null) return Response(result);

            //Then check dataBase
            result = _repository.GetBy(_ => _.Name == conversion);

            if (result != null)
            {
                _cache.Set<Quote>($"quote_{currency}", result);
                return Response(result);
            }

            //then check service
            var currencyConvertion = await _currencyLayerService.GetConvertionsFromUSD();

            if (currencyConvertion != null)
            {
                var updatedList = currencyConvertion.Quotes.Select(_ => new Quote(_.Key, _.Value)).ToList();
                _repository.AddOrUpdate(updatedList);

                result = updatedList.FirstOrDefault(_ => _.Name == conversion);
                if (result != null)
                {
                    _cache.Set<Quote>($"quote_{currency}", result);
                    return Response(result);
                }
            }

            return BadRequest(new
            {
                success = false,
                error = "Currency not found"
            });
        }
    }
}