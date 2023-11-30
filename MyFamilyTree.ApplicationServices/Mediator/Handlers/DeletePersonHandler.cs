

using AutoMapper;
using MediatR;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.DeletePerson;
using MyFamilyTree.ApplicationServices.ModelsDto;
using MyFamilyTree.Domain.CQRS.Commands;
using MyFamilyTree.Domain.CQRS.Commands.CommandManagement;
using MyFamilyTree.Domain.CQRS.Queries;
using MyFamilyTree.Domain.Entities;
using MyFamilyTreeAPI.Controllers;

namespace MyFamilyTree.ApplicationServices.Mediator.Handlers
{
    public class DeletePersonHandler : IRequestHandler<DeletePersonRequest, DeletePersonResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandexecutor;

        public DeletePersonHandler(IMapper mapper, ICommandExecutor commandexecutor)
        {
            this.mapper = mapper;
            this.commandexecutor = commandexecutor;
        }

        public async Task<DeletePersonResponse> Handle(DeletePersonRequest request, CancellationToken cancellationToken)
        {
            var person = new GetPersonByIdQuery { Id = request.Id };
            var mappedperson = mapper.Map<Person>(person);
            var command = new DeletePersonCommand { Parameter = mappedperson };
            var personfromdb = commandexecutor.Execute(command);
            var response= new DeletePersonResponse()
            { 
                Data = mapper.Map<CreateUserDto>(personfromdb) 
            };
            return response;
        }
    }
}
