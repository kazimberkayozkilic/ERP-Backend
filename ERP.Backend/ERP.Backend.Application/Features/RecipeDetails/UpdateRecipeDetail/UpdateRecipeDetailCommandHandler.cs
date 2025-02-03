using AutoMapper;
using ERP.Backend.Domain.Entities;
using ERP.Backend.Domain.Repositories;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace ERP.Backend.Application.Features.RecipeDetails.UpdateRecipeDetail
{
    internal sealed class UpdateRecipeDetailCommandHandler(IRecipeDetailRepository recipeDetailRepository, IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdateRecipeDetailCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateRecipeDetailCommand request, CancellationToken cancellationToken)
        {
            RecipeDetail recipeDetail = await recipeDetailRepository.GetByExpressionWithTrackingAsync(p => p.Id == request.Id, cancellationToken);
            if (recipeDetail is null)
            {
                return Result<string>.Failure("Reçetede bu ürün bulunamadı");
            }

            RecipeDetail? oldRecipeDetail = await recipeDetailRepository.Where(p => p.Id != request.Id && p.ProductId == request.ProductId && p.RecipeId == recipeDetail.RecipeId).FirstOrDefaultAsync(cancellationToken);

            if (oldRecipeDetail is not null)
            {
                recipeDetailRepository.Delete(recipeDetail);
                oldRecipeDetail.Quantity += request.Quantity;
                recipeDetailRepository.Update(oldRecipeDetail);
            }
            else
            {
                mapper.Map(request, recipeDetail);
            }
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return "Reçetedeki ürün başarıyla güncellendi";
        }
    }
}
