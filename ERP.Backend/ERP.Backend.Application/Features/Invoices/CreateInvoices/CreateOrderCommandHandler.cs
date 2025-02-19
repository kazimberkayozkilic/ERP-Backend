using AutoMapper;
using ERP.Backend.Application.Features.Invoices.CreateInvoices;
using ERP.Backend.Domain.Entities;
using ERP.Backend.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

internal sealed class CreateOrderCommandHandler(IInvoiceRepository invoiceRepository, IStockMovementRepository stockMovementRepository ,IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateInvoiceCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
    {
        Invoice invoice = mapper.Map<Invoice>(request);
        if (invoice.Details is not null)
        {
            List<StockMovement> movements = new();
            foreach (var item in invoice.Details)
            {
                StockMovement movement = new()
                {
                    InvoiceId = item.InvoiceId,
                    NumberOfEntries = request.Type == 1 ? item.Quantity : 0,
                    NumberOfOutputs = request.Type == 2 ? item.Quantity : 0,
                    DepotId = item.DepotId,
                    Price = item.Price,
                    ProductId = item.ProductId
                };
                movements.Add(movement);
            }
             await stockMovementRepository.AddRangeAsync(movements, cancellationToken);
        }
        await invoiceRepository.AddAsync(invoice, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return "Fatura basarıyla olusturuldu.";
    }
}