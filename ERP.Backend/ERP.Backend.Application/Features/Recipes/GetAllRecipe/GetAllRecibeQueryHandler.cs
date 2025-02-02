using ERP.Backend.Domain.Entities;
using ERP.Backend.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace ERP.Backend.Application.Features.Recipes.GetAllRecipe
{
    internal sealed class GetAllRecibeQueryHandler(IRecipeRepository recipeRepository) : IRequestHandler<GetAllRecipeQuery, Result<List<Recipe>>>
    {
        public async Task<Result<List<Recipe>>> Handle(GetAllRecipeQuery request, CancellationToken cancellationToken)
        {
            List<Recipe> recipes = await recipeRepository.GetAll().Include(p => p.Product).OrderBy(p => p.Product!.Name).ToListAsync(cancellationToken);
            return recipes;
        }
    }
}
