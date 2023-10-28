using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyFamilyTree.ApplicationServices.API.Domain.Mediator.RequestResponses;
using MyFamilyTree.DataAccess.CQRS.Commands;

namespace MyFamilyTreeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly IMediator mediator;

        public PeopleController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet]
        [Route("ShowAllPeople")]
        public async Task<IActionResult> GetPeople([FromQuery] GetPeopleRequest request)
        {
            var response = await this.mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("person{Id}")]
        public async Task<IActionResult> GetPersonById([FromBody] GetPeopleRequest request)
        {
            var response = await this.mediator.Send(request);
            return Ok(response);
        }
        [HttpPost]
        [Route("addPerson")]
        public async Task<IActionResult> AddPerson([FromBody] AddPersonRequest request)
        {
            var response = await this.mediator.Send(request);
            return Ok(response);
        }

    }
}
