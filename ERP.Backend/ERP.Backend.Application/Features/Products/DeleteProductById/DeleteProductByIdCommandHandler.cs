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

namespace ERP.Backend.Application.Features.Products.DeleteProductById
{
    internal sealed class DeleteProductByIdCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteProductByIdCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
        {
            Product product = await productRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);
            if (product == null)
            {
                return Result<string>.Failure("Ürün bulunamadı.");
            }
            productRepository.Delete(product);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return "Ürün başarıyla silindi.";
        }
    }
}
