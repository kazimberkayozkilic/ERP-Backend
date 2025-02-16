using ERP.Backend.Domain.Entities;
using ERP.Backend.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace ERP.Backend.Application.Features.Orders.RequirementsPlanningByOrderId
{
    internal sealed class RequirementsPlanningByOrderIdCommandHandler(IOrderReporsitory orderReporsitory) : IRequestHandler<RequirementsPlanningByOrderIdCommand, Result<RequirementsPlanningByOrderIdCommandResponse>>
    {
        public async Task<Result<RequirementsPlanningByOrderIdCommandResponse>> Handle(RequirementsPlanningByOrderIdCommand request, CancellationToken cancellationToken)
        {
            Order? order = await orderReporsitory.Where(p => p.Id == request.Id).Include(p => p.Details).FirstOrDefaultAsync(cancellationToken);

            if (order is null)
            {
                return Result<RequirementsPlanningByOrderIdCommandResponse>.Failure("Sipariş bulunamadı");
            }
            return new RequirementsPlanningByOrderIdCommandResponse(DateOnly.FromDateTime(DateTime.Now), order.Number + "Nolu Siparişin İhtiyaç Planlaması", new());
        }
    }
}
