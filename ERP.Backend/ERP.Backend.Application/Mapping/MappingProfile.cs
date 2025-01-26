using AutoMapper;
using ERP.Backend.Application.Features.Customers.CreateCustomer;
using ERP.Backend.Domain.Entities;

namespace ERP.Backend.Application.Mapping
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCustomerCommand, Customer>();
        }
    }
}
