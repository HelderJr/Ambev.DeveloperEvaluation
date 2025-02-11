using Ambev.DeveloperEvaluation.Application.Products.GetProducts;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct
{
    public class GetProductProfile : Profile
    {
        public GetProductProfile()
        {
            CreateMap<GetProductResult, GetProductResponse>();
        }
    }
}
