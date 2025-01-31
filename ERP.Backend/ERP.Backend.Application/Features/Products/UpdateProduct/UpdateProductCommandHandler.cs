using AutoMapper;
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

namespace ERP.Backend.Application.Features.Products.UpdateProduct
{
    internal class UpdateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdateCommandProduct, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateCommandProduct request, CancellationToken cancellationToken)
        {
            Product product = await productRepository.GetByExpressionWithTrackingAsync(p => p.Id == request.Id, cancellationToken);

            if (product == null)
            {
                return Result<string>.Failure("Ürün bulunamadı");
            }
            if(product.Name != request.Name)
            {
                bool isNameExist = await productRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);
                if (isNameExist)
                {
                    return Result<string>.Failure("Ürün ismi zaten mevcut");
                }
            }
            mapper.Map(request, product);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return "Ürün başarıyla güncellendi";
        }
    }
}
