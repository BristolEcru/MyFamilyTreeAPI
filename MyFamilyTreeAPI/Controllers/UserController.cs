using MediatR;
using Microsoft.AspNetCore.Mvc;

using MyFamilyTree.Domain.CQRS.Commands;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.GetAllUsers;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.CreateUser;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.LoginUser;
using MagazynEdu.Authentication;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.GetUser;

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
        [Route("getUser")]
        public Task<IActionResult> GetUser([FromQuery] GetUserRequest request)
        {
            return HandleRequest<GetUserRequest, GetUserResponse>(request);

        }

        [HttpGet]
        [Route("getUsers")]
        public Task<IActionResult> GetAllUsers([FromQuery] GetUsersRequest request)
        {
            return HandleRequest<GetUsersRequest, GetUsersResponse>(request);

        }

        [AllowAnonymous]
        [HttpPost]
        [Route("createUser")]
        public Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            return HandleRequest<CreateUserRequest, CreateUserResponse>(request);
        }

      
    }
}
