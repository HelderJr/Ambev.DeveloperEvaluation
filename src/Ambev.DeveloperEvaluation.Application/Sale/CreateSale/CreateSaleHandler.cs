using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sale.CreateSale
{
    public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly ISaleProductRepository _saleProductRepository;
        private readonly IMapper _mapper;

        public CreateSaleHandler(ISaleRepository saleRepository, 
                                 ISaleProductRepository saleProductRepository,
                                 IMapper mapper)
        {
            _saleRepository = saleRepository;
            _saleProductRepository = saleProductRepository;
            _mapper = mapper;
        }
        public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
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
            return result;
        }
    }
}
