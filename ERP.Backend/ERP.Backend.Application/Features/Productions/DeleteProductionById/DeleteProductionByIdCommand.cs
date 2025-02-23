using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace ERP.Backend.Application.Features.Productions.DeleteProductionById
{
    public sealed record DeleteProductionByIdCommand(Guid Id) : IRequest<Result<string>>;
    
}
