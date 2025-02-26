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
    internal sealed class GetAllProductQueryHandler(
     IProductRepository productRepository,
     IStockMovementRepository stockMovementRepository) : IRequestHandler<GetAllProductQuery, Result<List<GetAllProductQueryResponse>>>
    {
        public async Task<Result<List<GetAllProductQueryResponse>>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            List<Product> products = await productRepository.GetAll().OrderBy(p => p.Name).ToListAsync(cancellationToken);

            List<GetAllProductQueryResponse> response = products.Select(s => new GetAllProductQueryResponse
            {
                Id = s.Id,
                Name = s.Name,
                Type = s.Type,
                Stock = 0
            }).ToList();

            foreach (var item in response)
            {
                decimal stock =
                    await stockMovementRepository.Where(p => p.ProductId == item.Id)
                    .SumAsync(s => s.NumberOfEntries - s.NumberOfOutputs);

                item.Stock = stock;
            }

            return response;
        }
    }


}
