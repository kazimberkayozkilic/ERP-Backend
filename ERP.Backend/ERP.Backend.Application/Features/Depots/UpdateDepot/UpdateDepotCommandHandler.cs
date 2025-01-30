﻿using AutoMapper;
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

namespace ERP.Backend.Application.Features.Depots.UpdateDepot
{
    internal sealed class UpdateDepotCommandHandler(IDepotRepository depotRepository, IUnitOfWork unitOfWork,   IMapper mapper) : IRequestHandler<UpdateDepotCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateDepotCommand request, CancellationToken cancellationToken)
        {
            Depot depot = await depotRepository.GetByExpressionWithTrackingAsync(p => p.Id == request.Id, cancellationToken);

            if (depot is null)
            {
                return Result<string>.Failure("Depo bulunamadı");
            }
            mapper.Map(request, depot);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return "Depo başarılı bir şekilde guncellendi";
        }
    }
}
