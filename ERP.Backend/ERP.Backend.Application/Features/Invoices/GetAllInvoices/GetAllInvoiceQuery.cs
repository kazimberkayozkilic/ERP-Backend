using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Backend.Application.Features.Invoices.GetAllInvoices
{
    public sealed record GetAllInvoiceQuery(int Type) : IRequest<List<Invoice>>;
}
