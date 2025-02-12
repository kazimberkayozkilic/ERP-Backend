using ERP.Backend.Domain.Entities;
using ERP.Backend.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Backend.Infrastructure.Configurations
{
    internal sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(p => p.Status).HasConversion(status => status.Value, value => OrderStatüsEnum.FromValue(value));
        }
    }
}
