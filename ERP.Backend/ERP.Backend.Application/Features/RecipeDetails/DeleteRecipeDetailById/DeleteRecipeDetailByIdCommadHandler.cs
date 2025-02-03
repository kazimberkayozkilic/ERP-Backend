using ERP.Backend.Domain.Entities;
using GenericRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace ERP.Backend.Application.Features.RecipeDetails.DeleteRecipeDetailById
{
    public sealed class DeleteRecipeDetailByIdCommadHandler(IRecipeDetailRepository recipeDetailRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteRecipeDetailByIdCommad, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteRecipeDetailByIdCommad request, CancellationToken cancellationToken)
        {
            RecipeDetail recipeDetail =await recipeDetailRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);
            if (recipeDetail is null)
            {
                return Result<string>.Failure("Reçete bu ürün bulunamadı");
            }
            recipeDetailRepository.Delete(recipeDetail);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return "Ürün reçeteden basarıyla silindi";
        }
    }
}
