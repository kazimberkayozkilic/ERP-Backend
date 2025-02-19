using ERP.Backend.Domain.Entities;
using ERP.Backend.Domain.Repositories;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace ERP.Backend.Application.Features.Invoices.DeleteInvoiceById
{
    internal sealed class DeleteInvoiceByIdCommandHandler(IInvoiceRepository invoiceRepository, IStockMovementRepository stockMovementRepository ,IUnitOfWork unitOfWork) : IRequestHandler<DeleteInvoiceByIdCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteInvoiceByIdCommand request, CancellationToken cancellationToken)
        {
            Invoice? invoice = await invoiceRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);
            if(invoice is null)
            {
                return Result<string>.Failure("Fatura bulunamadı");
            }
            List<StockMovement> movements = await stockMovementRepository.Where(p => p.InvoiceId == invoice.Id).ToListAsync(cancellationToken);
            stockMovementRepository.DeleteRange(movements);
            invoiceRepository.Delete(invoice);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return "Fatura başarıyla silindi.";
        }
    }
}
