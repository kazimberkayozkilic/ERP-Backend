using ERP.Backend.Application.Features.Depots.CreateDepot;
using ERP.Backend.Application.Features.Depots.DeleteDepotById;
using ERP.Backend.Application.Features.Depots.GetAllDepot;
using ERP.Backend.Application.Features.Depots.UpdateDepot;
using ERP.Backend.Application.Features.Invoices.CreateInvoices;
using ERP.Backend.Application.Features.Invoices.DeleteInvoiceById;
using ERP.Backend.Application.Features.Invoices.GetAllInvoices;
using ERP.Backend.Application.Features.Invoices.UpdateInvoice;
using ERP.Backend.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Backend.WebAPI.Controllers
{
    public sealed class InvoicesController : ApiController
    {
        public InvoicesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> GetAll(GetAllInvoiceQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteById(DeleteInvoiceByIdCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            return StatusCode(response.StatusCode, response);
        }

    }
}
