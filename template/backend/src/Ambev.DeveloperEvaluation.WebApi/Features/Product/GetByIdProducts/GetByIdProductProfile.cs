using Ambev.DeveloperEvaluation.Application.Product.GetByIdProduct; 
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetByIdProducts;

public class GetByIdProductProfile : Profile
{
    public GetByIdProductProfile()
    {
        CreateMap<GetByIdProductRequest, GetByIdProductCommand>();
        CreateMap<GetByIdProductResult, GetByIdProductResponse>();
    }
}
