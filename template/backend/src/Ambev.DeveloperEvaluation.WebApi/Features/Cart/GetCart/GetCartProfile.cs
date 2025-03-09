using Ambev.DeveloperEvaluation.Application.Cart.GetCart;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Cart.GetCart;

public class GetCartProfile : Profile
{
    public GetCartProfile()
    {
        CreateMap<GetCartRequest, GetCartCommand>();
        CreateMap<GetCartResult, GetCartResponse>()
            .ForMember(
            CartResult => CartResult.Products,
            CartResponse => CartResponse.MapFrom(r => r.CartItems));
    }

}