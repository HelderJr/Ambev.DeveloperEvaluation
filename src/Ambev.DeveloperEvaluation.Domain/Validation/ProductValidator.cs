using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(product => product.Name)
                .NotEmpty()
                .MinimumLength(3).WithMessage("Productname must be at least 3 characters long.")
                .MaximumLength(20).WithMessage("Productname cannot be longer than 20 characters.");

            RuleFor(product => product.Description)
                .NotEmpty()
                .MinimumLength(3).WithMessage("Productdescription must be at least 3 characters long.")
                .MaximumLength(50).WithMessage("Productdescription cannot be longer than 50 characters.");

            RuleFor(product => product.Price)
                .NotEmpty()
                .GreaterThan(0).WithMessage("price must be greater than 0.00");

        }
    }
}
