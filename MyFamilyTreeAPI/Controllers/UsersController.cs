using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.GetAllUsers;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.CreateUser;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.LoginUser;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.GetUser;

namespace MyFamilyTree.Presentation.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ApiBaseController
    {
        public UsersController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("get_user")]
        public Task<IActionResult> GetUser([FromQuery] GetUserRequest request)
        {
            return HandleRequest<GetUserRequest, GetUserResponse>(request);

        }

        [HttpGet]
        [Route("get_users")]
        public Task<IActionResult> GetAllUsers([FromQuery] GetUsersRequest request)
        {
            return HandleRequest<GetUsersRequest, GetUsersResponse>(request);

        }

        [AllowAnonymous]
        [HttpPost]
        [Route("create_user")]
        public Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            return HandleRequest<CreateUserRequest, CreateUserResponse>(request);
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public Task<IActionResult> Login([FromBody] LoginUserRequest request)
        {
            return HandleRequest<LoginUserRequest, LoginUserResponse>(request);
        }

    }
}
