﻿using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;


namespace Ambev.DeveloperEvaluation.Application.Cart.GetAllCart;

public class GetAllCartCommand : IRequest<List<GetAllCartResult>>
{
    public int PageNumber { get; set; } = 1;

    public int PageSize { get; set; } = 10;

    public string OrderBy { get; set; } = string.Empty;

    public ValidationResultDetail Validate()
    {
        var validator = new GetAllCartCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}