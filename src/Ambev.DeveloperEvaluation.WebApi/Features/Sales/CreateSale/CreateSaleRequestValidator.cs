using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
    {
        public CreateSaleRequestValidator()
        {
            RuleFor(sale => sale.CustomerId)
                .NotEmpty().WithMessage("CustomerId required");

            RuleFor(sale => sale.Products)
               .NotEmpty().WithMessage("There are no products in the list");
        }
    }
}
