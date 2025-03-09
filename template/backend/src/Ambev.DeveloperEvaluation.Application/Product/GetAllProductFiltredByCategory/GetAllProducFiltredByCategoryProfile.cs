using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Product.GetAllProductFiltredByCategory
{
    public class GetAllProducFiltredByCategoryProfile : Profile
    {
        public GetAllProducFiltredByCategoryProfile()
        {
            CreateMap<GetAllProductFiltredByCategoryCommand, Ambev.DeveloperEvaluation.Domain.Entities.Product> ();
            CreateMap<Ambev.DeveloperEvaluation.Domain.Entities.Product, GetAllProductFiltredByCategoryResult>();
        }
    }
}
