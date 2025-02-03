using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace ERP.Backend.Application.Features.RecipeDetails.CreateRecipeDetail
{
    public sealed record CreateRecipeDetailCommand(Guid RecipeId, Guid ProductId, decimal Quantity): IRequest<Result<string>>;
    
}
