using ERP.Backend.Domain.Entities;
using ERP.Backend.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace ERP.Backend.Application.Features.Productions.GetAllProduction
{
    internal sealed class GetAllProductionQueryHAndler(IProductionRepository  productionRepository) : IRequestHandler<GetAllProductionQuery, Result<List<Production>>>
    {
        public async Task<Result<List<Production>>> Handle(GetAllProductionQuery request, CancellationToken cancellationToken)
        {
            List<Production> productions = await productionRepository.GetAll().Include(p => p.Product).Include(p => p.Depot).OrderByDescending(p => p.CreatedAt).ToListAsync(cancellationToken);
            return productions;
        }
    }
}
