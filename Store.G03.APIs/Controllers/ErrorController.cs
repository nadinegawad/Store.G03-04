using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.G03.APIs.Error;

namespace Store.G03.APIs.Controllers
{
    [Route("error/[code]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        public ErrorController() { }
        public IActionResult Error(int code)
        {
            return NotFound(new ApiErrorResponse(StatusCodes.Status404NotFound,"Not Found End Point"));
        }
    }
}
