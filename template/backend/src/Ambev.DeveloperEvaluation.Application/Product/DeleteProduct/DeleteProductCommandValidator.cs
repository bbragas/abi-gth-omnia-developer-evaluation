﻿using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Product.DeleteProduct
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Product ID is required");
        }
    }
}
