using ERP.Backend.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Backend.Domain.Entities
{
    public sealed class Depot: Entity
    {
        public string Name {get; set;} = string.Empty;
        public string City {get; set;}= string.Empty;
        public string Town {get; set;} = string.Empty;
        public string FullAddress { get; set; } = string.Empty;
    }
}
