
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.AddPerson;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.GetAllPeople;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.GetPersonById;
using MyFamilyTree.Domain.CQRS.Commands;
using MyFamilyTree.Presentation.Controllers;

namespace MyFamilyTreeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : ApiBaseController
    {
        public PeopleController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("showAllPeople")]
        public  Task<IActionResult> GetPeople([FromQuery] GetPeopleRequest request)
        {
           return  HandleRequest<GetPeopleRequest, GetPeopleResponse>(request);
        }

        [HttpGet]
        [Route("{Id}")]
        public  Task<IActionResult> GetPersonById([FromRoute] int id)
        {
            var request = new GetPersonByIdRequest { Id = id };
            return  HandleRequest<GetPersonByIdRequest, GetPersonByIdResponse>(request);
        }

        [HttpPost]
        [Route("addPerson")]
        public async Task<IActionResult> AddPerson([FromBody] AddPersonRequest request)
        {
            if(!ModelState.IsValid) {
                return BadRequest("BAD_REQUEST_13");
            }
            var response = await this.mediator.Send(request);
            return Ok(response);
        }

    }
}
