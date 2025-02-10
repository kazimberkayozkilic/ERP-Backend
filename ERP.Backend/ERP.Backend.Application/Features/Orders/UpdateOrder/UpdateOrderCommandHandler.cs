﻿using AutoMapper;
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

namespace ERP.Backend.Application.Features.Orders.UpdateOrder
{
    internal sealed class UpdateOrderCommandHandler(IOrderReporsitory orderReporsitory, IOrderDetailRepository orderDetailRepository , IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdateOrderCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            Order? order = await orderReporsitory.Where(p => p.Id == request.Id).Include(p => p.Details).FirstOrDefaultAsync();
            if ( order is null ) {
                return Result<string>.Failure("Sipariş bulunamadı.");
            }
            orderDetailRepository.DeleteRange(order.Details);
            mapper.Map(request, order);
            await unitOfWork.SaveChangesAsync();
            return "Sipariş basarıyla güncellendi.";
           
        }
    }
}
