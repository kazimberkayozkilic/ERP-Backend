using ERP.Backend.Domain.Entities;
using ERP.Backend.Domain.Repositories;
using ERP.Backend.Infrastructure.Context;
using GenericRepository;

internal sealed class RecipeDetailRepository : Repository<RecipeDetail, ApplicationDbContext>, IRecipeDetailRepository
{
    public RecipeDetailRepository(ApplicationDbContext context) : base(context)
    {
    }
}
