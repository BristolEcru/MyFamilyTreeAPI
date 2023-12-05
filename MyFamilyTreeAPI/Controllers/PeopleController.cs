
using Azure;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.AddPerson;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.DeletePerson;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.EditPerson;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.GetPeople;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.GetPersonById;
using MyFamilyTree.Presentation.Controllers;
using System.Threading.Tasks;

namespace MyFamilyTreeAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ApiBaseController
    {
        public PeopleController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetPeople([FromQuery] GetPeopleRequest request)
        {
            return await HandleRequest<GetPeopleRequest, GetPeopleResponse>(request);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetPersonById([FromRoute] int id)
        {

            var request = new GetPersonByIdRequest { Id = id };
            return await HandleRequest<GetPersonByIdRequest, GetPersonByIdResponse>(request);
        }

        [HttpPost]
        [Route("add_person")]
        public async Task<IActionResult> AddPerson([FromBody] AddPersonRequest request)
        {
            return await HandleRequest<AddPersonRequest, AddPersonResponse>(request);
        }

        [HttpPost]
        [Route("edit_person")]
        public async Task<IActionResult> EditPerson([FromBody] EditPersonRequest request)
        {
            return await HandleRequest<EditPersonRequest, EditPersonResponse>(request);
        }
        [HttpDelete]
        [Route("delete_person")]
        public async Task<IActionResult> DeletePerson([FromBody] DeletePersonRequest request)
        {
            return await HandleRequest<DeletePersonRequest, DeletePersonResponse>(request);
        }
    }
}
