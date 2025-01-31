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

namespace ERP.Backend.Application.Features.Products.GetAllProduct
{
    internal sealed class GetAllQueryHandler(IProductRepository productRepository) : IRequestHandler<GetAllProductQuery, Result<List<Product>>>
    {
        public async Task<Result<List<Product>>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            List<Product> products = await productRepository.GetAll().OrderBy(p => p.Name).ToListAsync(cancellationToken);
            return products;
        }
    }
}
