using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Product.CreateProduct;

public class CreateProductProfile : Profile
{
    public CreateProductProfile()
    {
        CreateMap<CreateProductCommand, Ambev.DeveloperEvaluation.Domain.Entities.Product>();
        CreateMap<Ambev.DeveloperEvaluation.Domain.Entities.Product, CreateProductResult>();
    }
}
