using ERP.Backend.Domain.Repositories;
using GenericRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace ERP.Backend.Application.Features.Invoices.DeleteInvoiceById
{
    internal sealed class DeleteInvoiceByIdCommandHandler(IInvoiceRepository invoiceRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteInvoiceByIdCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteInvoiceByIdCommand request, CancellationToken cancellationToken)
        {
            Invoice? invoice = await invoiceRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);
            if(invoice is null)
            {
                return Result<string>.Failure("Fatura bulunamadı");
            }
            invoiceRepository.Delete(invoice);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return "Fatura başarıyla silindi.";
        }
    }
}
