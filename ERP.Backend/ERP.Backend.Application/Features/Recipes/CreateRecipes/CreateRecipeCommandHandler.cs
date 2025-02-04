using ERP.Backend.Domain.Entities;
using ERP.Backend.Domain.Repositories;
using GenericRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace ERP.Backend.Application.Features.Recipes.CreateRecipes
{
    internal sealed class CreateRecipeCommandHandler(IRecipeRepository recipeRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateRecipeCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
        {
            bool isRecipeExists = await recipeRepository.AnyAsync(p => p.ProductId == request.ProductId, cancellationToken);
            if (isRecipeExists)
            {
                return Result<string>.Failure("Bu ürün için bir tarım tarifi bulunmaktadır.");
            }
            Recipe recipe = new()
            {
                ProductId = request.ProductId,
                Details = request.Details.Select(p => new RecipeDetail()
                {
                    ProductId = p.ProductId,
                    Quantity = p.Quantity
                }).ToList()
            };

            await recipeRepository.AddAsync(recipe);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return "Reçete kaydı başarıyla oluşturuldu.";
        }
    }
}
