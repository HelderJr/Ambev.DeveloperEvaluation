using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sale.CreateSale
{
    public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
    {
        public CreateSaleCommandValidator()
        {
            RuleFor(sale => sale.Products)
                .NotEmpty().WithMessage("There are no products in the list");

            RuleFor(sale => sale.TotalValue)
                .NotEmpty()
                .GreaterThan(0).WithMessage("total value must be greater than 0.00");
        }
    }
}
