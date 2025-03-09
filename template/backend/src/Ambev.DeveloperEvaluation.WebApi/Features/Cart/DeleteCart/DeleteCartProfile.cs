using Ambev.DeveloperEvaluation.Application.Cart.DeleteCart;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Cart.DeleteCart;

public class DeleteCartProfile : Profile
{
    public DeleteCartProfile()
    {
        CreateMap<DeleteCartRequest, DeleteCartCommand>();
    }
}
