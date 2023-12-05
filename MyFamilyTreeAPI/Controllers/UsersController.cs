using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.GetAllUsers;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.CreateUser;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.LoginUser;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.GetUser;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetUser([FromQuery] GetUserRequest request)
        {
            return await HandleRequest<GetUserRequest, GetUserResponse>(request);

        }

        [HttpGet]
        [Route("get_users")]
        public async Task<IActionResult> GetAllUsers([FromQuery] GetUsersRequest request)
        {
            return await HandleRequest<GetUsersRequest, GetUsersResponse>(request);

        }

        [AllowAnonymous]
        [HttpPost]
        [Route("create_user")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            return await HandleRequest<CreateUserRequest, CreateUserResponse>(request);
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserRequest request)
        {
            return await HandleRequest<LoginUserRequest, LoginUserResponse>(request);
        }

    }
}
