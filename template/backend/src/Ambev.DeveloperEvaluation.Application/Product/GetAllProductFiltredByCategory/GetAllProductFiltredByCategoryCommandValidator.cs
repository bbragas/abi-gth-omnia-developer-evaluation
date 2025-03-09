using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Product.GetAllProductFiltredByCategory
{
    public class GetAllProductFiltredByCategoryCommandValidator : AbstractValidator<GetAllProductFiltredByCategoryCommand>
    {
        public GetAllProductFiltredByCategoryCommandValidator()
        {
            RuleFor(x => x.PageNumber).NotEmpty().WithMessage("PageNumber is required");
            RuleFor(x => x.PageSize).NotEmpty().WithMessage("PageSize is required");
        }
    }
}
