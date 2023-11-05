using MediatR;
using Microsoft.AspNetCore.Mvc;

using MyFamilyTree.Domain.CQRS.Commands;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.GetAllUsers;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.CreateUser;

namespace MyFamilyTree.Presentation.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ApiBaseController
    {
        public UserController(IMediator mediator) : base(mediator)
        {
        }


        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllUsers([FromQuery] GetUsersRequest request)
        {
            return HandleRequest<GetUsersRequest, GetUsersResponse>(request);

        }

        [AllowAnonymous]
        [HttpPost]
        [Route("")]
        public Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            return HandleRequest<CreateUserRequest, CreateUserResponse>(request);
        }

    }
}
