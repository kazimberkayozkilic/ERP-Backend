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
    internal sealed class DepotRepository : Repository<Depot, ApplicationDbContext>, IDepotRepository
    {
        public DepotRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
