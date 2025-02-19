using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace ERP.Backend.Application.Features.Invoices.GetAllInvoices
{
    public sealed record GetAllInvoiceQuery(int Type) : IRequest<Result<List<Invoice>>>;
}
