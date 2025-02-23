using ERP.Backend.Application.Features.Productions.CreateProduction;
using ERP.Backend.Application.Features.Productions.DeleteProductionById;
using ERP.Backend.Application.Features.Productions.GetAllProduction;
using ERP.Backend.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Backend.WebAPI.Controllers
{
    public sealed class ProductionsController : ApiController
    {
        public ProductionsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> GetAll(GetAllProductionQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductionCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteById(DeleteProductionByIdCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}
