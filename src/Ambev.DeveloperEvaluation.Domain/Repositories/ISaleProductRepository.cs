using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ISaleProductRepository
    {
        Task CreateAsync(IEnumerable<SaleProduct> products, CancellationToken cancellationToken = default);

        Task<IEnumerable<SaleProduct>?> GetBySaleIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
