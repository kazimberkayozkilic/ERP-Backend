using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace ERP.Backend.Application.Features.Customers.UpdateCustomer
{
    public sealed record UpdateCustomerCommand(string Name, string TaxDepartment, string TaxNumber, string City, string Town, string FullAddress) : IRequest<Result<string>>;
   
}
