using Microsoft.AspNetCore.Mvc;

namespace RightStakes.Challenge.Services.WebAPI.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        protected new IActionResult Response(object result = null)
        {
            if (IsValidOperation())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                //errors = _notifications.GetNotifications().Select(n => n.Value)
            });
        }

        protected bool IsValidOperation()
        {
            return true;
        }
    }
}