using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace ERP.Backend.Application.Features.Invoices.UpdateInvoice
{
    public sealed record UpdateInvoiceCommand(Guid Id, Guid CustomerId, Guid? OrderId, DateOnly Date, string InvoiceNumber, List<InvoiceDetailDto> Details) : IRequest<Result<string>>;
   
}
