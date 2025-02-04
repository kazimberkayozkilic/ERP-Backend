using ERP.Backend.Domain.Entities;
using ERP.Backend.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace ERP.Backend.Application.Features.RecipeDetails.GetByIdRecipeWithDetails
{
    internal sealed class GetByIdRecipeWithDetailsQueryHandler(IRecipeRepository recipeRepository) : IRequestHandler<GetByIdRecipeWithDetailsQuery, Result<Recipe>>
    {
        public async Task<Result<Recipe>> Handle(GetByIdRecipeWithDetailsQuery request, CancellationToken cancellationToken)
        {
            Recipe? recipe = await recipeRepository.Where(p => p.Id == request.Id)
                .Include(p => p.Product)
                .Include(p => p.Details!)
                .ThenInclude(p => p.Product)
                .FirstOrDefaultAsync(cancellationToken);

            if (recipe == null)
            {
                return Result<Recipe>.Failure("Ürüne ait reçete bilgisi bulunamadı.");
            }

            return recipe;
        }
    }
}
