using ERP.Backend.Domain.Repositories;
using ERP.Backend.Infrastructure.Context;
using GenericRepository;

internal sealed class InvoiceDetailRepository : Repository<InvoiceDetail, ApplicationDbContext>, IInvoiceDetailRepository
{
    public InvoiceDetailRepository(ApplicationDbContext context) : base(context)
    {
    }
}
