using Ambev.DeveloperEvaluation.Application.Cart.GetAllCart;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Cart.GetAllCart;

public class GetAllCartProfile : Profile
{
    public GetAllCartProfile()
    {
        CreateMap<GetAllCartRequest, GetAllCartCommand>();
        CreateMap<GetAllCartResult, GetAllCartResponse>()
            .ForMember(
            CartResult => CartResult.Products,
            CartResponse => CartResponse.MapFrom(r => r.CartItems));
    }
}
