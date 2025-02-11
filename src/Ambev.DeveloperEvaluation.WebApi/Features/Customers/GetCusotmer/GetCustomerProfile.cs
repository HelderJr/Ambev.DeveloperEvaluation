using Ambev.DeveloperEvaluation.Application.Customers.GetCustomers;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.GetCusotmer
{
    public class GetCustomerProfile : Profile
    {
        public GetCustomerProfile()
        {
            CreateMap<GetCustomerResult, GetCustomerResponse>();
        }
    }
}
