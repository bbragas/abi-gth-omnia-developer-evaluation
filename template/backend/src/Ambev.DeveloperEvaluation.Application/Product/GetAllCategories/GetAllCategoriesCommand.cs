﻿using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Product.GetAllCategories
{
    public class GetAllCategoriesCommand : IRequest<GetAllCategoriesResult>
    {
        public ValidationResultDetail Validate()
        {
            var validator = new GetAllCategoriesCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
