using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleRequest
    {
        public Subsidiary Subsidiary { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CustomerId { get; set; }
        public IEnumerable<Product> Products { get; set; } = [];
    }
}
