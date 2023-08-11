using AutoMapper;
using CasgemMicroservice.Services.Catalog.Dtos.CategoryDtos;
using CasgemMicroservice.Services.Catalog.Dtos.ProductDtos;
using CasgemMicroservice.Services.Catalog.Models;

namespace CasgemMicroservice.Services.Catalog.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<ResultProductDto, Product>().ReverseMap();
            CreateMap<CreateProductDto, Product>().ReverseMap();
            CreateMap<UpdateProductDto, Product>().ReverseMap();


            CreateMap<ResultCategoryDto, Category>().ReverseMap();
            CreateMap<CreateCategoryDto, Category>().ReverseMap();
            CreateMap<UpdateCategoryDto, Category>().ReverseMap();
        }
    }
}
