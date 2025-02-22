﻿using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProducts
{
    public class GetProductValidator : AbstractValidator<GetProductCommand>
    {
        public GetProductValidator()
        {
            RuleFor(x => x.Id)
             .NotEmpty()
             .WithMessage("Product ID is required");
        }
    }
}
