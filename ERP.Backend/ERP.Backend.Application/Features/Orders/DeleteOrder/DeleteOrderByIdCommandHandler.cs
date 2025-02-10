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

namespace ERP.Backend.Application.Features.Orders.DeleteOrder
{
    internal sealed class DeleteOrderByIdCommandHandler(IOrderReporsitory orderReporsitory, IUnitOfWork unitOfWork) : IRequestHandler<DeleteOrderByIdCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteOrderByIdCommand request, CancellationToken cancellationToken)
        {
            Order order = await orderReporsitory.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);
            if (order == null)
            {
                return Result<string>.Failure("Sipariş bulunamadı");
            }
            orderReporsitory.Delete(order);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return "Sipariş başarıyla silindi";
        }
    }
}
