using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class SaleProductRepository : ISaleProductRepository
    {
        private readonly DefaultContext _context;

        public SaleProductRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(IEnumerable<SaleProduct> products, CancellationToken cancellationToken = default)
        {
            await _context.SaleProducts.AddRangeAsync(products, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<SaleProduct>?> GetBySaleIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.SaleProducts.Where(o => o.SaleId == id).ToListAsync(cancellationToken);
        }
    }
}
