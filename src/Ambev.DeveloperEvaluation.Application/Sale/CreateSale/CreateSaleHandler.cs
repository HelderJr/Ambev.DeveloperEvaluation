using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.ORM;
using AutoMapper;
using FluentValidation;
using MassTransit;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sale.CreateSale
{
    public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
    {
        private readonly DefaultContext _context;
        private readonly ISaleRepository _saleRepository;
        private readonly ISaleProductRepository _saleProductRepository;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;


        public CreateSaleHandler(DefaultContext context,
                                 ISaleRepository saleRepository, 
                                 ISaleProductRepository saleProductRepository,
                                 IMapper mapper,
                                 IPublishEndpoint publishEndpoint)
        {
            _context = context;
            _saleRepository = saleRepository;
            _saleProductRepository = saleProductRepository;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }
        public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
        {
            using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                var validator = new CreateSaleCommandValidator();
                var validationResult = await validator.ValidateAsync(command, cancellationToken);

                if (!validationResult.IsValid)
                    throw new ValidationException(validationResult.Errors);

                var sale = _mapper.Map<Domain.Entities.Sale>(command);
                var createdSale = await _saleRepository.CreateAsync(sale, cancellationToken);

                var saleProducts = new List<SaleProduct>();

                foreach (var product in sale.Products)
                    saleProducts.Add(new() { SaleId = createdSale.Id, ProductId = product.Id });

                await _saleProductRepository.CreateAsync(saleProducts, cancellationToken);

                var result = _mapper.Map<CreateSaleResult>(createdSale);

                await transaction.CommitAsync(cancellationToken);

                await _publishEndpoint.Publish(new SaleCreatedEvent { SaleId = sale.Id }, cancellationToken);

                return result;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync(cancellationToken); 
                throw;
            }
        }
    }
}
