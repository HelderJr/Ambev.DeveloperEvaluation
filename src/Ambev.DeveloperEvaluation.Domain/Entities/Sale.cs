using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale
    {
        public int Id { get; set; }
        public decimal TotalValue { get; set; }
        public Subsidiary Subsidiary { get; set; }
        public IEnumerable<Product> Products { get; set; } = [];
        public int Quantities { get; set; }
        public float Discount { get; set; }
        public bool WasCanceled { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public ICollection<SaleProduct> SaleProducts { get; set; } = new List<SaleProduct>();


        /// <summary>
        /// Calculates the total value of the sale with applicable discounts.
        /// </summary>
        public void CalculateTotal()
        {
            if (Quantities < 1)
                throw new ArgumentException("Quantity must be at least 1.");

            if (Quantities > 20)
                throw new ArgumentException("Maximum limit exceeded. You can only buy up to 20 items per sale.");

            decimal subtotal = Products.Sum(p => p.Price) * Quantities;
            float discountPercentage = 0;

            if (Quantities >= 4 && Quantities < 10)
                discountPercentage = 0.10f; // 10% discount
            else if (Quantities >= 10 && Quantities <= 20)
                discountPercentage = 0.20f; // 20% discount

            Discount = discountPercentage * 100; // Store discount percentage
            TotalValue = subtotal - (subtotal * (decimal)discountPercentage);
        }
    }
}
