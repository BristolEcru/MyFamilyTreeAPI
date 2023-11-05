using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.BaseClasses;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.Bases;
using System.Security.Claims;

namespace MyFamilyTree.Presentation.Controllers
{
    public abstract class ApiBaseController : ControllerBase
    {
        protected readonly IMediator mediator;

        public ApiBaseController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        protected async Task<IActionResult> HandleRequest<TRequest, TResponse>(TRequest request)
            where TRequest : IRequest<TResponse>
            where TResponse : ErrorResponseBase
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("BAD_REQUEST_13");
            }

            var response = await this.mediator.Send(request);
            if (response.Error != null)
            {
              //    return ErrorResponseBase(response.Error);
            }

            return Ok(response);
        }

    }
}
