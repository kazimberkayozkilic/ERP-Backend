﻿using AutoMapper;
using ERP.Backend.Application.Features.Customers.CreateCustomer;
using ERP.Backend.Application.Features.Customers.UpdateCustomer;
using ERP.Backend.Application.Features.Depots.CreateDepot;
using ERP.Backend.Application.Features.Depots.UpdateDepot;
using ERP.Backend.Domain.Entities;

namespace ERP.Backend.Application.Mapping
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCustomerCommand, Customer>();
            CreateMap<UpdateCustomerCommand, Customer>();
            CreateMap<CreateDepotCommand, Depot>();
            CreateMap<UpdateDepotCommand, Depot>();

        }
    }
}
