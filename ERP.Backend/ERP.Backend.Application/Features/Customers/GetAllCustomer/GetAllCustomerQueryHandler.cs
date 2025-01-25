using ERP.Backend.Domain.Entities;
using ERP.Backend.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace ERP.Backend.Application.Features.Customers.GetAllCustomer
{
    internal sealed class GetAllCustomerQueryHandler(
    ICustomerRepository customerRepository) : IRequestHandler<GetAllCustomerQuery, Result<List<Customer>>>
    {
        public async Task<Result<List<Customer>>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
        {
            List<Customer> customers = await customerRepository.GetAll().OrderBy(p => p.Name).ToListAsync(cancellationToken);

            return customers;
        }
    }
}
