using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly DefaultContext _defaultContext;

        public SaleRepository(DefaultContext defaultContext)
        {
            _defaultContext = defaultContext;
        }

        public async Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default)
        {
            await _defaultContext.Sales.AddAsync(sale, cancellationToken);
            await _defaultContext.SaveChangesAsync(cancellationToken);
            return sale;
        }

        public async Task<Sale?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _defaultContext.Sales.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);

        }
    }
}
