using AutoMapper; 

namespace Ambev.DeveloperEvaluation.Application.Cart.GetCart;

public class GetCartProfile : Profile
{
    public GetCartProfile()
    {
        CreateMap<GetCartCommand, Ambev.DeveloperEvaluation.Domain.Entities.Cart>();
        CreateMap<Ambev.DeveloperEvaluation.Domain.Entities.Cart, GetCartResult>();
    }
}