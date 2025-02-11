using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.CreateCustomer
{
    public class CreateCustomerRequestValidator : AbstractValidator<CreateCustomerRequest>
    {
        public CreateCustomerRequestValidator()
        {
            RuleFor(customer => customer.Email).SetValidator(new EmailValidator());

            RuleFor(customer => customer.Name)
                .NotEmpty()
                .MinimumLength(3).WithMessage("Customername must be at least 3 characters long.")
                .MaximumLength(20).WithMessage("Customername cannot be longer than 20 characters.");
        }
    }
}
