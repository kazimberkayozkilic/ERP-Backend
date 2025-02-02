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

namespace ERP.Backend.Application.Features.Recipes.DeleteRecipeByIdCommand.cs
{
    internal sealed class DeleteRecipeByIdCommandHandler(IRecipeRepository recipeRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteRecipeByIdCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteRecipeByIdCommand request, CancellationToken cancellationToken)
        {
            Recipe recipe = await recipeRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);
            recipeRepository.Delete(recipe);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return "Reçete başarıyla silindi.";
        }
    }
}
