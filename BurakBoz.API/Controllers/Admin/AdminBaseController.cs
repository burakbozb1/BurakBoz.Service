using BurakBoz.Core.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BurakBoz.API.Controllers.Admin
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class AdminBaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(CustomResponseDto<T> response)
        {
            if (response.StatusCode == 204)
            {
                return new ObjectResult(null)
                {
                    StatusCode = response.StatusCode
                };
            }

            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
