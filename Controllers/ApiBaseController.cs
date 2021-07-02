using Microsoft.AspNetCore.Mvc;

namespace WebApiVersioning.Controllers
{
    public abstract class ApiBaseController : ControllerBase
    {
        [HttpOptions]
        public IActionResult Options()
        {
            return Ok(string.Empty);
        }
    }
}