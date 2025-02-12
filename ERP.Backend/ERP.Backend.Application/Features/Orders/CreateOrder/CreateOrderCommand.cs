using ERP.Backend.Domain.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace ERP.Backend.Application.Features.Orders.CreateOrder
{
    public sealed record class CreateOrderCommand(Guid CustomerId, DateOnly Date, DateOnly DeliveryDate, List<OrderDetailDto> Details) : IRequest<Result<string>>;
    
}
