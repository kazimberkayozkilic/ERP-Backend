using ERP.Backend.Application.Features.RecipeDetails.CreateRecipeDetail;
using ERP.Backend.Application.Features.RecipeDetails.DeleteRecipeDetailById;
using ERP.Backend.Application.Features.RecipeDetails.GetByIdRecipeWithDetails;
using ERP.Backend.Application.Features.RecipeDetails.UpdateRecipeDetail;
using ERP.Backend.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Backend.WebAPI.Controllers
{
    public sealed class RecipeDetailsController : ApiController
    {
        public RecipeDetailsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> GetRecipeByIdWithDetails(GetByIdRecipeWithDetailsQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRecipeDetailCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteById(DeleteRecipeDetailByIdCommad request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateRecipeDetailCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            return StatusCode(response.StatusCode, response);
        }
    }
}
