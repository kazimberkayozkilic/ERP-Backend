using ERP.Backend.Domain.Abstractions;
using ERP.Backend.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Backend.Domain.Entities
{
    public sealed class Product: Entity
    {
        public string Name { get; set; } = string.Empty;
        public ProductTypeEnum Type { get; set; } = ProductTypeEnum.Product;
    }
}
