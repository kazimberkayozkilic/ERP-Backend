using ERP.Backend.Domain.Abstractions;
using ERP.Backend.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Backend.Domain.Entities
{
    public sealed class Order : Entity
    {
        public Guid CustomerId { get; set; }
        public Customer? Customer{ get; set; }
        public int OrderNumberYear{ get; set; }
        public int OrderNumber{ get; set; }
        public DateOnly Date{ get; set; }
        public DateOnly DeliveryDate{ get; set; }
        public OrderStatüsEnum Status { get; set; } = OrderStatüsEnum.Pending;
        public List<OrderDetail>? Details { get; set; }
    }
}
