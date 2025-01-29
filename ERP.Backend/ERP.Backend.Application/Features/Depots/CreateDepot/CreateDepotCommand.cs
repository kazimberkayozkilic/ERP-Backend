using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace ERP.Backend.Application.Features.Depots.CreateDepot
{
    public sealed record CreateDepotCommand(string Name, string City, string Town, string FullAddress): IRequest<Result<string>>;
}
