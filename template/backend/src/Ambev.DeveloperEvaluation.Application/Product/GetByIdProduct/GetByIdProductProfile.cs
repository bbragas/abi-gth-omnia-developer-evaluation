using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Product.GetByIdProduct
{
    public class GetByIdProductProfile : Profile
    {
        public GetByIdProductProfile()
        {
            CreateMap<GetByIdProductCommand, Ambev.DeveloperEvaluation.Domain.Entities.Product>();
            CreateMap<Ambev.DeveloperEvaluation.Domain.Entities.Product, GetByIdProductResult>();
        }
    }
}
