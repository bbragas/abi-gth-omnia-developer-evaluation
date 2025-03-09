using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Product.GetByIdProduct
{
    public class GetByIdProductCommandValidator : AbstractValidator<GetByIdProductCommand>
    {
        public GetByIdProductCommandValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("User ID is required");
        }
    }
}
