using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Cart.DeleteCart;

public class DeleteCartCommandValidator : AbstractValidator<DeleteCartCommand>
{
    public DeleteCartCommandValidator()
    {
        RuleFor(x => x.Id)
        .NotEmpty()
        .WithMessage("Cart ID is required");
    }
}
