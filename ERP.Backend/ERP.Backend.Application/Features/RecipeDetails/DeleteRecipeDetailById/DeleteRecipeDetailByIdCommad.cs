using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace ERP.Backend.Application.Features.RecipeDetails.DeleteRecipeDetailById
{
    public sealed record DeleteRecipeDetailByIdCommad(Guid Id) : IRequest<Result<String>>;
    
}
