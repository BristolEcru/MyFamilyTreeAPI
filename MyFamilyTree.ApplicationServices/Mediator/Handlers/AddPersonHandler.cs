

using AutoMapper;
using MediatR;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.AddPerson;
using MyFamilyTree.ApplicationServices.ModelsDto;
using MyFamilyTree.Domain.CQRS.Commands;
using MyFamilyTree.Domain.CQRS.Commands.CommandManagement;
using MyFamilyTree.Domain.Entities;

namespace MyFamilyTree.ApplicationServices.Mediator.Handlers
{
    public class AddPersonHandler : IRequestHandler<AddPersonRequest, AddPersonResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public AddPersonHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<AddPersonResponse> Handle(AddPersonRequest request, CancellationToken cancellationToken)
        {
            var person = mapper.Map<Person>(request);
            var command = new AddPersonCommand() { Parameter = person };
            var personfromdb = await commandExecutor.Execute(command);
            return new AddPersonResponse()
            {
                Data = mapper.Map<CreateUserDto>(personfromdb)
            };
        }
    }
}
