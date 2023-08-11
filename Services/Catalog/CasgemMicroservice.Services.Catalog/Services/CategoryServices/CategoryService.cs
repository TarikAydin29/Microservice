using AutoMapper;
using CasgemMicroservice.Services.Catalog.Dtos.CategoryDtos;
using CasgemMicroservice.Services.Catalog.Models;
using CasgemMicroservice.Services.Catalog.Settings;
using CasgemMicroservice.Shared.Dtos;
using MongoDB.Driver;

namespace CasgemMicroservice.Services.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> categoryCollection;
        private readonly IMapper mapper;
        public CategoryService(IMapper mapper, IDbSettings dbSettings)
        {
            this.mapper = mapper;
            var client = new MongoClient(dbSettings.ConnectionString);
            var database = client.GetDatabase(dbSettings.DatabaseName);

            categoryCollection = database.GetCollection<Category>(dbSettings.CategoryCollectionName);
        }


        public async Task<Response<NoContent>> CreateCategoryAsync(CreateCategoryDto dto)
        {
            var value = mapper.Map<Category>(dto);
            await categoryCollection.InsertOneAsync(value);
            return Response<NoContent>.Success(204);
        }

        public async Task<Response<NoContent>> DeleteCategoryAsync(string id)
        {
            var value = await categoryCollection.DeleteOneAsync(x => x.CategoryID == id);
            return Response<NoContent>.Success(204);
        }

        public async Task<Response<List<ResultCategoryDto>>> GetAllCategoryAsync()
        {
            var values = await categoryCollection.Find(x => true).ToListAsync();
            return Response<List<ResultCategoryDto>>.Success(mapper.Map<List<ResultCategoryDto>>(values), 200);
        }

        public async Task<Response<ResultCategoryDto>> GetByIdCategoryAsync(string id)
        {
            var value = await categoryCollection.Find<Category>(x => x.CategoryID == id).FirstOrDefaultAsync();
            if (value == null)
            {
                return Response<ResultCategoryDto>.Fail("Kategori Bulunamadı", 404);
            }
            else
            {
                return Response<ResultCategoryDto>.Success(mapper.Map<ResultCategoryDto>(value), 200);
            }
        }

        public async Task<Response<NoContent>> UpdateCategoryAsync(UpdateCategoryDto dto)
        {
            var value = mapper.Map<Category>(dto);
            var result = await categoryCollection.FindOneAndReplaceAsync(x => x.CategoryID == dto.CategoryID, value);
            if (result == null)
            {
                return Response<NoContent>.Fail("Kategori Bulunamadı", 404);
            }
            else
            {
                return Response<NoContent>.Success(204);
            }
        }
    }
}
