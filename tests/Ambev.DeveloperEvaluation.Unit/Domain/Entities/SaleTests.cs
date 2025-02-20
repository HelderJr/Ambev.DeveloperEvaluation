using Xunit;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    public class SaleTests
    {
        [Fact]
        public void CalculateTotal_QuantityLessThanOne_ShouldThrowArgumentException()
        {
            // Arrange
            var sale = new Sale
            {
                Quantities = 0,
                Products = new List<Product> { new Product { Price = 100 } }
            };

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => sale.CalculateTotal());
            Assert.Equal("Quantity must be at least 1.", exception.Message);
        }

        [Fact]
        public void CalculateTotal_QuantityGreaterThanTwenty_ShouldThrowArgumentException()
        {
            // Arrange
            var sale = new Sale
            {
                Quantities = 21,
                Products = new List<Product> { new Product { Price = 100 } }
            };

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => sale.CalculateTotal());
            Assert.Equal("Maximum limit exceeded. You can only buy up to 20 items per sale.", exception.Message);
        }

        [Fact]
        public void CalculateTotal_QuantityBetween4And9_ShouldApply10PercentDiscount()
        {
            // Arrange
            var sale = new Sale
            {
                Quantities = 5,
                Products = new List<Product> { new Product { Price = 100 } }
            };

            // Act
            sale.CalculateTotal();

            // Assert
            Assert.Equal(5 * 100 * 0.9m, sale.TotalValue); // 10% discount applied
            Assert.Equal(10, sale.Discount); // 10% discount
        }

        [Fact]
        public void CalculateTotal_QuantityBetween10And20_ShouldApply20PercentDiscount()
        {
            // Arrange
            var sale = new Sale
            {
                Quantities = 15,
                Products = new List<Product> { new Product { Price = 100 } }
            };

            // Act
            sale.CalculateTotal();

            // Assert
            Assert.Equal(15 * 100 * 0.8m, sale.TotalValue); // 20% discount applied
            Assert.Equal(20, sale.Discount); // 20% discount
        }

        [Fact]
        public void CalculateTotal_Quantity1_ShouldHaveNoDiscount()
        {
            // Arrange
            var sale = new Sale
            {
                Quantities = 1,
                Products = new List<Product> { new Product { Price = 100 } }
            };

            // Act
            sale.CalculateTotal();

            // Assert
            Assert.Equal(100, sale.TotalValue); // No discount applied
            Assert.Equal(0, sale.Discount); // No discount
        }

        [Fact]
        public void CalculateTotal_ShouldCalculateCorrectTotalForMultipleProducts()
        {
            // Arrange
            var sale = new Sale
            {
                Quantities = 3,
                Products = new List<Product>
                {
                    new Product { Price = 100 },
                    new Product { Price = 50 }
                }
            };

            // Act
            sale.CalculateTotal();

            // Assert
            Assert.Equal((100 + 50) * 3, sale.TotalValue); // No discount applied
            Assert.Equal(0, sale.Discount); // No discount
        }
    }
}
