namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct
{
    public class GetProductResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}
