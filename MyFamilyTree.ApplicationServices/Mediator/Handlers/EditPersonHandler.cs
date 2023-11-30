using AutoMapper;
using MediatR;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.CreateUser;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.EditPerson;
using MyFamilyTree.ApplicationServices.ModelsDto;
using MyFamilyTree.Domain.CQRS.Commands;
using MyFamilyTree.Domain.CQRS.Commands.CommandManagement;
using MyFamilyTree.Domain.Entities;

namespace MyFamilyTree.ApplicationServices.Mediator.Handlers
{
    public class EditPersonHandler : IRequestHandler<EditPersonRequest, EditPersonResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        public EditPersonHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }
        public async Task<EditPersonResponse> Handle(EditPersonRequest request, CancellationToken cancellationToken)
        {
            var editedperson = mapper.Map<Person>(request);
            var command = new EditPersonCommand { Parameter= editedperson };    
            var personfromdb = await commandExecutor.Execute(command);
            var response = new EditPersonResponse()
            {
                Data = mapper.Map<CreateUserDto>(personfromdb)
            };
            return response;
        }
    }
}
