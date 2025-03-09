using Ambev.DeveloperEvaluation.Application.Product.GetAllProductFiltredByCategory;  
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetAllProductFiltredByCategory;

public class GetAllProductFiltredByCategoryProfile : Profile
{
    public GetAllProductFiltredByCategoryProfile()
    {
        CreateMap<GetAllProductFiltredByCategoryRequest, GetAllProductFiltredByCategoryCommand>();
        CreateMap<GetAllProductFiltredByCategoryResult, GetAllProductFiltredByCategoryResponse>(); 
    }
}
