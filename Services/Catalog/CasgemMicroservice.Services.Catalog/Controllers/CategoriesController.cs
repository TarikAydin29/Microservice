using CasgemMicroservice.Services.Catalog.Dtos.CategoryDtos;
using CasgemMicroservice.Services.Catalog.Services.CategoryServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasgemMicroservice.Services.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryList()
        {
            var values = await categoryService.GetAllCategoryAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(string id)
        {
            var value = await categoryService.GetByIdCategoryAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto dto)
        {
            await categoryService.CreateCategoryAsync(dto);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            await categoryService.DeleteCategoryAsync(id);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto dto)
        {
            await categoryService.UpdateCategoryAsync(dto);
            return Ok();
        }
    }
}
