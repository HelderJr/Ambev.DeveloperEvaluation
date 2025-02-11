using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleResponse
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
    }
}
