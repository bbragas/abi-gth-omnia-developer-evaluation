﻿using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Cart.CreateCart;

public class CreateCartCommand : IRequest<CreateCartResult>
{
    public int UserId { get; set; }

    public DateTime Date { get; set; }

    public List<CartItem> CartItems { get; set; } = new List<CartItem>();

    public ValidationResultDetail Validate()
    {
        var validator = new CreateCartCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}