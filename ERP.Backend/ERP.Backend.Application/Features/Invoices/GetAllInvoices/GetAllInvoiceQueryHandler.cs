﻿using ERP.Backend.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace ERP.Backend.Application.Features.Invoices.GetAllInvoices
{
    internal sealed class GetAllInvoiceQueryHandler(IInvoiceRepository invoiceRepository) : IRequestHandler<GetAllInvoiceQuery, Result<List<Invoice>>>
    {
        public async Task<Result<List<Invoice>>> Handle(GetAllInvoiceQuery request, CancellationToken cancellationToken)
        {
            List<Invoice> invoices = await invoiceRepository.Where(p => p.Type.Value == request.Type).OrderBy(p => p.Date).ToListAsync(cancellationToken);
            return invoices;
        }
    }
}
