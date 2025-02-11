using Ambev.DeveloperEvaluation.Application.Customers.CreateCustomers;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.CreateCustomer
{
    public class CreateCustomerProfile : Profile
    {
        public CreateCustomerProfile()
        {
            CreateMap<CreateCustomerRequest, CreateCustomerCommand>();
            CreateMap<CreateCustomerResult, CreateCustomerResponse>();
        }
    }
}
