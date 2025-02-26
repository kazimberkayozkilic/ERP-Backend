using MediatR;
using TS.Result;
using System.Collections.Generic;

namespace ERP.Backend.Application.Features.Products.GetAllProduct
{
    public sealed record GetAllProductQuery() : IRequest<Result<List<GetAllProductQueryResponse>>>;
}
