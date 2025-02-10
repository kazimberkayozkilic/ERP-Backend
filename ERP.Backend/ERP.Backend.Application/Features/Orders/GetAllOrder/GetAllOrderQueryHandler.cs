using ERP.Backend.Domain.Entities;
using ERP.Backend.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace ERP.Backend.Application.Features.Orders.GetAllOrder
{
    internal sealed class GetAllOrderQueryHandler(IOrderReporsitory orderReporsitory) : IRequestHandler<GetAllOrderQuery, Result<List<Order>>>
    {
        public async Task<Result<List<Order>>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
        {
            List<Order> orders = await orderReporsitory.GetAll().Include(p => p.Customer).Include(p => p.Details!).ThenInclude(p => p.Product).OrderByDescending(p => p.Date).ToListAsync(cancellationToken);
            return orders;
        }
    }
}
