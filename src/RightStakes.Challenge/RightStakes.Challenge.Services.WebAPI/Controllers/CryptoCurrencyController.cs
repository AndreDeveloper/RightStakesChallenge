using Microsoft.AspNetCore.Mvc;

namespace RightStakes.Challenge.Services.WebAPI.Controllers
{
    [ApiController]
    public class CryptoCurrencyController : ApiController
    {
        [HttpGet]
        [Route("cryptocurrencies")]
        public IActionResult Get()
        {
            return Response();
        }
    }
}