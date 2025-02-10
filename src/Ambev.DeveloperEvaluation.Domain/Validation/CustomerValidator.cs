using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.Email).SetValidator(new EmailValidator());

            RuleFor(customer => customer.Name)
                .NotEmpty()
                .MinimumLength(3).WithMessage("Customername must be at least 3 characters long.")
                .MaximumLength(20).WithMessage("Customername cannot be longer than 20 characters.");
        }
    }
}
