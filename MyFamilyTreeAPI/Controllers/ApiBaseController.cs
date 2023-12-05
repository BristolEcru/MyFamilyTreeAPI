using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.Bases;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

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
                return this.BadRequest(
                    this.ModelState
                    .Where(x => x.Value.Errors.Any())
                    .Select(x => new { property = x.Key, errors = x.Value.Errors }));
            }
            
            var username = this.User.FindFirstValue(ClaimTypes.Name);
            var userrole = this.User.FindFirstValue(ClaimTypes.Role);
   

            var response = await this.mediator.Send(request);
            if (response.Error != null)
            {
              return ErrorResponseBase(response.Error);
            }

            //if(HttpContext.Response.StatusCode==200)
            //    await Console.Out.WriteLineAsync("mamy 200");
            //if (User.Claims.IsNullOrEmpty() && !response.Equals(null))
            //{ var result = await HttpContext.AuthenticateAsync("BasicAuthentication");
            //    await Console.Out.WriteLineAsync(result.Ticket.Properties.ToString());
            //}

            return Ok(response);

             IActionResult ErrorResponseBase(ErrorModel errormodel)
            {
                var httpCode = GetHttpStatusCode(errormodel.Error);
                return StatusCode((int)httpCode, errormodel);
            }
        }

        public static HttpStatusCode GetHttpStatusCode(string errorType)
        {
            switch (errorType)
            {
                case ErrorTypes.NotFound:
                    return HttpStatusCode.NotFound;
                case ErrorTypes.Unauthorized:
                    return HttpStatusCode.Unauthorized;
                case ErrorTypes.ValidationError:
                    return HttpStatusCode.UnprocessableEntity;
                case ErrorTypes.InternalServerError:
                    return HttpStatusCode.InternalServerError;
                case ErrorTypes.BadRequest:
                    return HttpStatusCode.BadRequest;
                case ErrorTypes.Forbidden:
                    return HttpStatusCode.Forbidden;
                case ErrorTypes.Timeout:
                    return HttpStatusCode.RequestTimeout;
                case ErrorTypes.ServiceUnavailable:
                    return HttpStatusCode.ServiceUnavailable;
                case ErrorTypes.Conflict:
                    return HttpStatusCode.Conflict;
                case ErrorTypes.NotImplemented:
                    return HttpStatusCode.NotImplemented;
                default:
                    return HttpStatusCode.BadRequest;
            }
        }

    }
}
