using ERP.Backend.Domain.Abstractions;
using ERP.Backend.Domain.Entities;
using ERP.Backend.Domain.Enums;

public sealed class Invoice : Entity
{
    public Guid CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public string InvoiceNumber { get; set; } = string.Empty;
    public DateOnly Date { get; set; }
    public InvoinceTypeEnum Type{ get; set; } = InvoinceTypeEnum.Purchase;
    public List<InvoiceDetail>? Details{ get; set; }
}
