using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Backend.Domain.Dtos
{
   public sealed record ProductDto(string Name, decimal Quantity);
}
