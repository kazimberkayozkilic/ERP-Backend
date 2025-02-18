using ERP.Backend.Domain.Dtos;
using ERP.Backend.Domain.Entities;
using ERP.Backend.Domain.Enums;
using ERP.Backend.Domain.Repositories;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace ERP.Backend.Application.Features.Orders.RequirementsPlanningByOrderId
{
    internal sealed class RequirementsPlanningByOrderIdCommandHandler(IOrderReporsitory orderReporsitory, IUnitOfWork unitOfWork , IRecipeRepository recipeRepository, IStockMovementRepository stockMovementRepository) : IRequestHandler<RequirementsPlanningByOrderIdCommand, Result<RequirementsPlanningByOrderIdCommandResponse>>
    {
        public async Task<Result<RequirementsPlanningByOrderIdCommandResponse>> Handle(RequirementsPlanningByOrderIdCommand request, CancellationToken cancellationToken)
        {
            Order? order = await orderReporsitory
                .Where(p => p.Id == request.OrderId)
                .Include(p => p.Details!)
                .ThenInclude(p => p.Product)
                .FirstOrDefaultAsync(cancellationToken);

            if (order is null)
            {
                return Result<RequirementsPlanningByOrderIdCommandResponse>.Failure("Sipariş bulunamadı");
            }
            List<ProductDto> uretilmesiGerekenUrunListesi = new();
            List<ProductDto> requirementsPlanningProduct = new();
            if (order.Details is not null)
            {
                foreach (var item in order.Details)
                {
                    var product = item.Product;
                    List<StockMovement> movements = await stockMovementRepository.Where(p => p.ProductId == product!.Id).ToListAsync(cancellationToken);
                    decimal stock = movements.Sum(p => p.NumberOfEntries) - movements.Sum(p => p.NumberOfOutputs);
                    if (stock < item.Quantity)
                    {
                        ProductDto uretilmesiGerekenUrun = new()
                        {
                            Id = item.ProductId,
                            Name = item.Product!.Name,
                            Quantity = item.Quantity,
                        };
                        uretilmesiGerekenUrunListesi.Add(uretilmesiGerekenUrun);
                    }
                }
                foreach (var item in uretilmesiGerekenUrunListesi)
                {
                    Recipe? recipe = await recipeRepository.Where(p => p.ProductId == item.Id).Include(p => p.Details!).ThenInclude(p => p.Product).FirstOrDefaultAsync(cancellationToken);
                    if (recipe is not null)
                    {
                        if (recipe.Details is not null)
                        {
                            foreach (var detail in recipe.Details)
                            {
                                List<StockMovement> urunMovements = await stockMovementRepository.Where(p => p.ProductId == detail.ProductId).ToListAsync(cancellationToken);
                                decimal stock = urunMovements.Sum(p => p.NumberOfEntries) - urunMovements.Sum(p => p.NumberOfOutputs);
                                if (stock < detail.Quantity)
                                {
                                    ProductDto ihtiyacOlanUrun = new()
                                    {
                                        Id = detail.ProductId,
                                        Name = detail.Product!.Name,
                                        Quantity = item.Quantity - stock,
                                    };

                                    requirementsPlanningProduct.Add(ihtiyacOlanUrun);
                                }
                        }
                        }
                    }
                }
            }

            requirementsPlanningProduct = requirementsPlanningProduct.GroupBy(p => p.Id).Select(g => new ProductDto { Id = g.Key, Name = g.First().Name, Quantity = g.Sum(p => p.Quantity) }).ToList();

            order.Status = OrderStatüsEnum.RequirementsPlanWorked;
            orderReporsitory.Update(order);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return new RequirementsPlanningByOrderIdCommandResponse(DateOnly.FromDateTime(DateTime.Now), order.Number + "Nolu Siparişin İhtiyaç Planlaması", new(requirementsPlanningProduct));
        }
    }
}
