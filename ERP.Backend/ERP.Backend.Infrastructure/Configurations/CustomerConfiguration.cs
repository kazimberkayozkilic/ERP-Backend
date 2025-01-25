using ERP.Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Backend.Infrastructure.Configurations
{
    internal sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(p => p.TaxNumber).HasColumnType("varchar(11)");
            builder.Property(p => p.Name).HasColumnType("varchar(50)");
            builder.Property(p => p.FullAddress).HasColumnType("varchar(100)");
            builder.Property(p => p.City).HasColumnType("varchar(20)");
            builder.Property(p => p.TaxDepartment).HasColumnType("varchar(20)");
            builder.Property(p => p.Town).HasColumnType("varchar(50)");
        }
    }
}
