using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Cart.CreateCart;
public class CreateCartProfile : Profile
{
    public CreateCartProfile()
    {
        CreateMap<CreateCartCommand, Ambev.DeveloperEvaluation.Domain.Entities.Cart>()
            .ForMember(
            Cart => Cart.CartItems,
            CartCommand => CartCommand.MapFrom(r => r.CartItems));

        CreateMap<Ambev.DeveloperEvaluation.Domain.Entities.Cart, CreateCartResult>();
    }
}