using ERP.Backend.Domain.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace ERP.Backend.Application.Features.Orders.UpdateOrder
{
    public sealed record class UpdateOrderCommand(Guid Id, Guid CustomerId, DateOnly Date, DateOnly DaliveryDate, List<OrderDetailDto> Details): IRequest<Result<string>>;
 
}
