﻿using ERP.Backend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace ERP.Backend.Application.Features.Orders.GetAllOrder
{
    public sealed class GetAllOrderQuery() : IRequest<Result<List<Order>>>;
    

}
