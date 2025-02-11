using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.GetCusotmer
{
    public class GetCustomerRequestValidator : AbstractValidator<GetCustomerRequest>
    {
        public GetCustomerRequestValidator()
        {
            RuleFor(x => x.Id)
               .NotEmpty()
               .WithMessage("Customer ID is required");
        }
    }
}
