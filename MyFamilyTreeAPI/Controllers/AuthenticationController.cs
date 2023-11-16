using MagazynEdu.Authentication;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.LoginUser;
using System.Reflection.Metadata;

namespace MyFamilyTree.Presentation.Controllers
{
    [ApiController]
    public class AuthenticationController : ApiBaseController
    {
            private readonly IAuthenticationService _authenticationService;

          

        public AuthenticationController(IAuthenticationService authenticationService,IMediator mediator) : base(mediator)
        {
            _authenticationService = authenticationService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult> Login([FromBody] LoginUserRequest request)
        {
                var result = await HttpContext.AuthenticateAsync("BasicAuthentication");

                if (result.Succeeded)
                {
                    // Użytkownik został uwierzytelniony pomyślnie - miejsce na jwt

                    return Ok("Zalogowano pomyślnie.");
                }

                return Unauthorized("Niepoprawne dane uwierzytelniania.");
            }

            // Inne akcje kontrolera, np. wylogowywanie
        }

    }
