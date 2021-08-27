using Microsoft.AspNetCore.Mvc;

namespace RightStakes.Challenge.Services.WebAPI.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        protected new IActionResult Response(object result = null)
        {
            return Ok(new
            {
                success = true,
                data = result
            });
        }
    }
}