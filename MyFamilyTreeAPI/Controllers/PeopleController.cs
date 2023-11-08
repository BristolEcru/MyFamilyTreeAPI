
using Azure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.AddPerson;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.DeletePerson;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.GetPeople;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.GetPersonById;
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
        [Route("")]
        public Task<IActionResult> GetPeople([FromQuery] GetPeopleRequest request)
        {

            return HandleRequest<GetPeopleRequest, GetPeopleResponse>(request);
        }

        [HttpGet]
        [Route("{Id}")]
        public Task<IActionResult> GetPersonById([FromRoute] int id)
        {

            var request = new GetPersonByIdRequest { Id = id };
            return HandleRequest<GetPersonByIdRequest, GetPersonByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddPerson([FromBody] AddPersonRequest request)
        {
            return HandleRequest<AddPersonRequest, AddPersonResponse>(request);
        }

        [HttpDelete]
        [Route("")]
        public Task<IActionResult> DeletePerson([FromBody] DeletePersonRequest request)
        {
            return HandleRequest<DeletePersonRequest, DeletePersonResponse>(request);
        }
    }   
}
