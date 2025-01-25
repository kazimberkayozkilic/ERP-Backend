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
    internal sealed class CustomerRepository : Repository<Customer, ApplicationDbContext>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
