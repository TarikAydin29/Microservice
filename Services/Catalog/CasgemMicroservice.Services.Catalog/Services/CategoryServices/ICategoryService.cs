using CasgemMicroservice.Services.Catalog.Dtos.CategoryDtos;
using CasgemMicroservice.Shared.Dtos;

namespace CasgemMicroservice.Services.Catalog.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<Response<List<ResultCategoryDto>>> GetAllCategoryAsync();
        Task<Response<ResultCategoryDto>> GetByIdCategoryAsync(string id);
        Task<Response<NoContent>> CreateCategoryAsync(CreateCategoryDto dto);
        Task<Response<NoContent>> UpdateCategoryAsync(UpdateCategoryDto dto);
        Task<Response<NoContent>> DeleteCategoryAsync(string id);
    }
}
