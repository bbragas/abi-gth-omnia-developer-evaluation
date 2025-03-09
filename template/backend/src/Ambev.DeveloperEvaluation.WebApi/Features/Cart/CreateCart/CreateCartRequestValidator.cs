using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Cart.CreateCart;

public class CreateCartRequestValidator : AbstractValidator<CreateCartRequest>
{
    public CreateCartRequestValidator()
    {
        RuleFor(cart => cart.UserId).NotEmpty().WithMessage("Cart User ID is required");
        RuleFor(cart => cart.Date).NotEmpty().WithMessage("Cart Date is required"); ;
    }
}