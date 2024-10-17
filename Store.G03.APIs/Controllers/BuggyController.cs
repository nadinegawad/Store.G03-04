using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.G03.APIs.Error;
using Store.G03.Repository.Data.context;

namespace Store.G03.APIs.Controllers
{
    
    public class BuggyController : BaseApiController
    {
        private readonly StoreDbContext _context;
        public BuggyController(StoreDbContext storeDbContext)
        {

        }
        [HttpGet("notfound")]
        public async Task< IActionResult> GetNotFoundRequestError()
        {
            var brand =await _context.ProductBrands.FindAsync(100);
            if (brand is null) return NotFound(new ApiErrorResponse(400));
            return Ok(brand);
        }

        [HttpGet("server")]
        public async Task<IActionResult> GetServerRequestError()
        {
            var brand = await _context.ProductBrands.FindAsync(100);
            var brandString = brand.ToString();
            if (brand is null) return NotFound(new ApiErrorResponse(400));
            return Ok(brand);
        }
        [HttpGet("badrequest")]
        public async Task<IActionResult> GetBadRequestError()
        {

            return BadRequest();
        }
        [HttpGet("badrequest-{id}")]
        public async Task<IActionResult> GetBadRequestError(int id)
        {

            return Ok();
        }
        [HttpGet("unaithorized")]
        public async Task<IActionResult> GetUnaithorizedRequestError(int id)
        {

            return Unauthorized(new ApiErrorResponse(401));
        }
    }
}
