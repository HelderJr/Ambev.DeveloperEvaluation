using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default);

        Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
