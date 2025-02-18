using Ardalis.SmartEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Backend.Domain.Enums
{
    public sealed class InvoinceTypeEnum : SmartEnum<InvoinceTypeEnum>
    {
        public static readonly InvoinceTypeEnum Purchase = new("Alış Faturası", 1);
        public static readonly InvoinceTypeEnum Sales = new("Satış Faturası", 2);

        public InvoinceTypeEnum(string name, int value) : base(name, value)
        {
        }
    }
}
