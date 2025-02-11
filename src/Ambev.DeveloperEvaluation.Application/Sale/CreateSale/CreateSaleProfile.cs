﻿using AutoMapper;


namespace Ambev.DeveloperEvaluation.Application.Sale.CreateSale
{
    public class CreateSaleProfile : Profile
    {
        public CreateSaleProfile()
        {
            CreateMap<CreateSaleCommand, Domain.Entities.Sale>();
            CreateMap<Domain.Entities.Sale, CreateSaleResult>();
        }
    }
}
