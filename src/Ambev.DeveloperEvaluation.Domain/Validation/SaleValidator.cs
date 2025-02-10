using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class SaleValidator : AbstractValidator<Sale>
    {
        public SaleValidator()
        {
            RuleFor(sale => sale.Products)
                .NotEmpty().WithMessage("There are no products in the list");

            RuleFor(sale => sale.TotalValue)
                .NotEmpty()
                .GreaterThan(0).WithMessage("total value must be greater than 0.00");
        }
    }
}
