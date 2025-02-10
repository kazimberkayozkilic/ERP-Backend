using Ardalis.SmartEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Backend.Domain.Enums
{
    public sealed class OrderStatüsEnum : SmartEnum<OrderStatüsEnum>
    {
        public static readonly OrderStatüsEnum Pending = new("Bekliyor" , 1);
        public static readonly OrderStatüsEnum RequirementsPlanWorked = new("İhtiyaç Planı Çalışıldı", 2);
        public static readonly OrderStatüsEnum Completed = new("Tamamlandı", 3);
        public OrderStatüsEnum(string name, int value) : base(name, value)
        {
        }
    }
}
