using ERP.Backend.Application.Features.Products.CreateProduct;
using ERP.Backend.Application.Features.Products.DeleteProductById;
using ERP.Backend.Application.Features.Products.GetAllProduct;
using ERP.Backend.Application.Features.Products.UpdateProduct;
using ERP.Backend.Application.Features.Recipes.CreateRecipes;
using ERP.Backend.Application.Features.Recipes.DeleteRecipeByIdCommand.cs;
using ERP.Backend.Application.Features.Recipes.GetAllRecipe;
using ERP.Backend.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Backend.WebAPI.Controllers
{
    public sealed class RecipesController : ApiController
    {
        public RecipesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> GetAll(GetAllRecipeQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRecipeCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteById(DeleteRecipeByIdCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            return StatusCode(response.StatusCode, response);
        }
    }
}
