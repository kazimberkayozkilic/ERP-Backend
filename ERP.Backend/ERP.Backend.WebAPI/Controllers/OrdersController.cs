using ERP.Backend.Application.Features.Customers.CreateCustomer;
using ERP.Backend.Application.Features.Customers.DeleteCustomerById;
using ERP.Backend.Application.Features.Customers.GetAllCustomer;
using ERP.Backend.Application.Features.Customers.UpdateCustomer;
using ERP.Backend.Application.Features.Orders.CreateOrder;
using ERP.Backend.Application.Features.Orders.DeleteOrder;
using ERP.Backend.Application.Features.Orders.GetAllOrder;
using ERP.Backend.Application.Features.Orders.UpdateOrder;
using ERP.Backend.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Backend.WebAPI.Controllers
{
    public sealed class OrdersController : ApiController
    {
        public OrdersController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> GetAll(GetAllOrderQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteById(DeleteOrderByIdCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            return StatusCode(response.StatusCode, response);
        }

    }
}
