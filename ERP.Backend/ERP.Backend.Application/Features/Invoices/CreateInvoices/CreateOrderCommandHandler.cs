using AutoMapper;
using ERP.Backend.Application.Features.Invoices.CreateInvoices;
using ERP.Backend.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

internal sealed class CreateOrderCommandHandler(IInvoiceRepository invoiceRepository, IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateOrderCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        Invoice invoice= mapper.Map<Invoice>(request);
        await invoiceRepository.AddAsync(invoice, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return "Fatura basarıyla olusturuldu.";
    }
}