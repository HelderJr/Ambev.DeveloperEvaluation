﻿using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Customers.GetCustomers
{
    public class GetCustomerHandler : IRequestHandler<GetCustomerCommand, GetCustomerResult>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetCustomerHandler(
            ICustomerRepository customerRepository,
            IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<GetCustomerResult> Handle(GetCustomerCommand request, CancellationToken cancellationToken)
        {
            var validator = new GetCustomerValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var user = await _customerRepository.GetByIdAsync(request.Id, cancellationToken);
            if (user == null)
                return null!;

            return _mapper.Map<GetCustomerResult>(user);
        }
    }
}
