using AutoMapper;
using ERP.Backend.Application.Features.Customers.CreateCustomer;
using ERP.Backend.Application.Features.Customers.UpdateCustomer;
using ERP.Backend.Application.Features.Depots.CreateDepot;
using ERP.Backend.Application.Features.Depots.UpdateDepot;
using ERP.Backend.Application.Features.Orders.CreateOrder;
using ERP.Backend.Application.Features.Orders.UpdateOrder;
using ERP.Backend.Application.Features.Products.CreateProduct;
using ERP.Backend.Application.Features.Products.UpdateProduct;
using ERP.Backend.Application.Features.RecipeDetails.CreateRecipeDetail;
using ERP.Backend.Application.Features.RecipeDetails.UpdateRecipeDetail;
using ERP.Backend.Domain.Entities;
using ERP.Backend.Domain.Enums;

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
            CreateMap<CreateProductCommand, Product>().ForMember(member => member.Type, options => options.MapFrom(p => ProductTypeEnum.FromValue(p.TypeValue)));
            CreateMap<UpdateCommandProduct, Product>().ForMember(member => member.Type, options => options.MapFrom(p => ProductTypeEnum.FromValue(p.TypeValue)));
            CreateMap<CreateRecipeDetailCommand, RecipeDetail>();
            CreateMap<UpdateRecipeDetailCommand, RecipeDetail>();
            CreateMap<CreateOrderCommand, Order>().ForMember(member => member.Details, options => options.MapFrom(p => p.Details.Select(s => new OrderDetail
            {
                Price = s.Price,
                ProductId = s.ProductId,
                Quantity = s.Quantity
            }).ToList()));
            CreateMap<UpdateOrderCommand, Order>().ForMember(member => member.Details, options => options.MapFrom(p => p.Details.Select(s => new OrderDetail
            {
                Price = s.Price,
                ProductId = s.ProductId,
                Quantity = s.Quantity
            }).ToList()));
        }
    }
}
