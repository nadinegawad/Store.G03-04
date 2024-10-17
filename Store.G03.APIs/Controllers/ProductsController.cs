using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.G03.APIs.Error;
using Store.G03.Core.Dtos.Products;
using Store.G03.Core.Entites;
using Store.G03.Core.Helper;
using Store.G03.Core.Services.contract;
using Store.G03.Core.Specifications;
using System.Collections.Generic;

namespace Store.G03.APIs.Controllers
{
   
    public class ProductsController : BaseApiController
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        [ProducesResponseType(typeof(PaginationResponse<ProductDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<PaginationResponse<ProductDto>>> GetAllProducts([FromQuery] ProductSpecParams productSpecParams)
        {
            var result = await _productService.GetAllProductsAsync(productSpecParams);
            return Ok(result);
        }
        [HttpGet("brands")]
        [ProducesResponseType(typeof(IEnumerable<ProductDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllBrands()
        {
            var result = await _productService.GetAllBrandsAsync();
            return Ok(result);
        }
        [HttpGet("types")]
        [ProducesResponseType(typeof(IEnumerable < ProductDto >), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllTypes()
        {
            var result = await _productService.GetAllTypesAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TypeBrandDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetproductById(int? id)
        {
            if (id is null) return BadRequest(new ApiErrorResponse(400));
            var result = await _productService.GetProductById(id.Value);
            if (result is null)
            {
                return NotFound(new ApiErrorResponse(400, $"The Product With Id :{id} Not Found in DB"));
            }
            return Ok(result);
        }
    }
}
