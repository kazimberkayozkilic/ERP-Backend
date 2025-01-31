using Ardalis.SmartEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Backend.Domain.Enums
{
    public sealed class ProductTypeEnum : SmartEnum<ProductTypeEnum>
    {
        public static readonly ProductTypeEnum Product = new("Mamül", 1);
        public static readonly ProductTypeEnum SemiProduct = new("Yarı Mamül", 2);

        public ProductTypeEnum(string name, int value) : base(name, value)
        {
        }
    }
}
