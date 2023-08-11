using CasgemMicroservice.Services.Catalog.Dtos.CategoryDtos;
using CasgemMicroservice.Services.Catalog.Dtos.ProductDtos;
using CasgemMicroservice.Services.Catalog.Services.CategoryServices;
using CasgemMicroservice.Services.Catalog.Services.ProductServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasgemMicroservice.Services.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        private readonly IProductService productService;

        public ProductsController(ICategoryService categoryService, IProductService productService)
        {
            this.categoryService = categoryService;
            this.productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductList()
        {
            var values = await productService.GetAllProductAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            var value = await productService.GetByIdProductAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto dto)
        {
            await productService.CreateProductAsync(dto);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await productService.DeleteProductAsync(id);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto dto)
        {
            await productService.UpdateProductAsync(dto);
            return Ok();
        }
    }
}
