using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Cart.GetCart;

public class GetCartCommandValidator : AbstractValidator<GetCartCommand>
{
    public GetCartCommandValidator()
    {
        RuleFor(x => x.Id)
        .NotEmpty()
        .WithMessage("Cart ID is required");
    }
}