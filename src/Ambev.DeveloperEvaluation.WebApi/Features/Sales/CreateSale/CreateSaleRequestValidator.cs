using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
    {
        public CreateSaleRequestValidator()
        {
            RuleFor(sale => sale.Products)
               .NotEmpty().WithMessage("There are no products in the list");

            RuleFor(sale => sale.TotalValue)
                .NotEmpty()
                .GreaterThan(0).WithMessage("total value must be greater than 0.00");
        }
    }
}
