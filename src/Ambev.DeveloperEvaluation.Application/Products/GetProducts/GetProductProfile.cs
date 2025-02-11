using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProducts
{
    public class GetProductProfile : Profile
    {
        public GetProductProfile()
        {
            CreateMap<Product, GetProductResult>();
        }
    }
}
