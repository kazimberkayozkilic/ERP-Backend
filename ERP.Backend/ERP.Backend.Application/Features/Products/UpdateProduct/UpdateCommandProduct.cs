using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace ERP.Backend.Application.Features.Products.UpdateProduct
{
    public sealed record UpdateCommandProduct(Guid Id, string Name, int TypeValue) : IRequest<Result<string>>;

}
