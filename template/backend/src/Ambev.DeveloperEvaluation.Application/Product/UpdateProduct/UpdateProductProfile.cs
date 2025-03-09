using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Product.UpdateProduct
{
    public class UpdateProductProfile : Profile
    {
        public UpdateProductProfile()
        {
            CreateMap<UpdateProductCommand, Ambev.DeveloperEvaluation.Domain.Entities.Product>();
            CreateMap<Ambev.DeveloperEvaluation.Domain.Entities.Product, UpdateProductResult>();
        }
    }
}
