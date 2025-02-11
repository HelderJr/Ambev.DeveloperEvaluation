using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Customers.GetCustomers
{
    public class GetCustomerValidator : AbstractValidator<GetCustomerCommand>
    {
        public GetCustomerValidator()
        {
            RuleFor(x => x.Id)
               .NotEmpty()
               .WithMessage("Customer ID is required");
        }
    }
}
