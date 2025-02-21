using ERP.Backend.Domain.Dtos;
using ERP.Backend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace ERP.Backend.Application.Features.Invoices.CreateInvoices
{
    public sealed record class CreateInvoiceCommand(Guid CustomerId, int TypeValue, DateOnly Date, string InvoiceNumber, List<InvoiceDetailDto> Details) : IRequest<Result<string>>;

}
