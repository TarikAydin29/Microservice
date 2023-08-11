using AutoMapper;
using CasgemMicroservice.Services.Catalog.Dtos.ProductDtos;
using CasgemMicroservice.Services.Catalog.Models;
using CasgemMicroservice.Services.Catalog.Settings;
using CasgemMicroservice.Shared.Dtos;
using MongoDB.Driver;

namespace CasgemMicroservice.Services.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> productCollection;
        private readonly IMongoCollection<Category> categoryCollection;
        private readonly IMapper mapper;
        public ProductService(IMapper mapper, IDbSettings dbSettings)
        {
            this.mapper = mapper;
            var client = new MongoClient(dbSettings.ConnectionString);
            var database = client.GetDatabase(dbSettings.DatabaseName);

            productCollection = database.GetCollection<Product>(dbSettings.ProductCollectionName);
            categoryCollection = database.GetCollection<Category>(dbSettings.CategoryCollectionName);
        }
        public async Task<Response<NoContent>> CreateProductAsync(CreateProductDto dto)
        {
            var value = mapper.Map<Product>(dto);
            await productCollection.InsertOneAsync(value);
            return Response<NoContent>.Success(201);
        }

        public async Task<Response<NoContent>> DeleteProductAsync(string id)
        {
            var value = await productCollection.DeleteOneAsync(x => x.ProductID == id);
            return Response<NoContent>.Success(204);
        }

        public async Task<Response<List<ResultProductDto>>> GetAllProductAsync()
        {
            var values = await productCollection.Find(x => true).ToListAsync();
            return Response<List<ResultProductDto>>.Success(mapper.Map<List<ResultProductDto>>(values), 200);
        }

        public async Task<Response<ResultProductDto>> GetByIdProductAsync(string id)
        {
            var value = await productCollection.Find<Product>(x => x.ProductID == id).FirstOrDefaultAsync();
            if (value == null)
            {
                return Response<ResultProductDto>.Fail("Ürün bulunamadı.", 404);
            }
            return Response<ResultProductDto>.Success(mapper.Map<ResultProductDto>(value), 200);
        }

        public async Task<Response<NoContent>> UpdateProductAsync(UpdateProductDto dto)
        {
            var value = mapper.Map<Product>(dto);
            var result = await productCollection.FindOneAndReplaceAsync(x => x.ProductID == dto.ProductID, value);
            return Response<NoContent>.Success(204);
        }
    }
}
