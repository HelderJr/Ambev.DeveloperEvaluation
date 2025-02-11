using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sale.CreateSale
{
    public class CreateSaleCommand : IRequest<CreateSaleResult>
    {
        public int Id { get; set; }
        public decimal TotalValue { get; set; }
        public Subsidiary Subsidiary { get; set; }
        public int Quantities { get; set; }
        public float Discount { get; set; }
        public bool WasCanceled { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CustomerId { get; set; }
        public IEnumerable<Product> Products { get; set; } = [];

        public ValidationResultDetail Validate()
        {
            var validator = new CreateSaleCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
