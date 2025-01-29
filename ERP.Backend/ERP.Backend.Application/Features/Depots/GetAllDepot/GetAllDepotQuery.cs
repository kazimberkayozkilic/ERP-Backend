using ERP.Backend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace ERP.Backend.Application.Features.Depots.GetAllDepot
{
    public sealed record GetAllDepotQuery() : IRequest<Result<List<Depot>>>
    
}
