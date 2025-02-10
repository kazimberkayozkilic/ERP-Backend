using ERP.Backend.Domain.Entities;
using ERP.Backend.Domain.Repositories;
using ERP.Backend.Infrastructure.Context;
using GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Backend.Infrastructure.Repositories
{
    internal sealed class OrderRepository : Repository<Order, ApplicationDbContext>, IOrderReporsitory
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
