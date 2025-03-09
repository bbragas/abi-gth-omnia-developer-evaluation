using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Cart.UpdateCart;

public class UpdateCartProfile : Profile
{
    public UpdateCartProfile()
    {
        CreateMap<UpdateCartCommand, Ambev.DeveloperEvaluation.Domain.Entities.Cart>()
            .ForMember(
            Cart => Cart.CartItems,
            CartCommand => CartCommand.MapFrom(r => r.Products));

        CreateMap<Ambev.DeveloperEvaluation.Domain.Entities.Cart, UpdateCartResult>();
    }
}
