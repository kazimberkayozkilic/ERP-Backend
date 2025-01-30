using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace ERP.Backend.Application.Features.Depots.UpdateDepot
{
    public sealed record UpdateDepotCommand(Guid Id, string Name, string City, string Town, string FullAddress) : IRequest<Result<string>>;
    
}
