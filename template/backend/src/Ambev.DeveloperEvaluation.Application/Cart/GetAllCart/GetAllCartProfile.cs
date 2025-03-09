using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Cart.GetAllCart;

public class GetAllCartProfile : Profile
{
    public GetAllCartProfile()
    {
        CreateMap<GetAllCartCommand, Ambev.DeveloperEvaluation.Domain.Entities.Cart>();
        CreateMap<Ambev.DeveloperEvaluation.Domain.Entities.Cart, GetAllCartResult>();
    }
}
