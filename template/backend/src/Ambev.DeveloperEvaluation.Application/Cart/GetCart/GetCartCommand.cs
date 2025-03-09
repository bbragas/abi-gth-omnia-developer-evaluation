using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Cart.GetCart;

public class GetCartCommand : IRequest<GetCartResult>
{
    public int Id { get; set; }

    public ValidationResultDetail Validate()
    {
        var validator = new GetCartCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}