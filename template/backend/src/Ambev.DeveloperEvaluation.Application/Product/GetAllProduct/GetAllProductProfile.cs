using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Product.GetAllProduct
{
    public class GetAllProductProfile : Profile
    {
        public GetAllProductProfile()
        {
            CreateMap<GetAllProductCommand, Ambev.DeveloperEvaluation.Domain.Entities.Product>();
            CreateMap<Ambev.DeveloperEvaluation.Domain.Entities.Product, GetAllProductResult>();
        }
    }
}
