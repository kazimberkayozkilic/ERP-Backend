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
        public string OrderNumber{ get; set; }= string.Empty;
        public DateTime Date{ get; set; }
        public DateTime DeliveryDate{ get; set; }
        public OrderStatüsEnum Status { get; set; } = OrderStatüsEnum.Pending;
        public List<OrderDetail>? Details { get; set; }
    }
}
