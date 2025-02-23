using ERP.Backend.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Backend.Domain.Entities
{
    public sealed class Production: Entity
    {
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
        public decimal Quantity { get; set; }
        public Guid DepotId { get; set; }
        public Depot? Depot { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
