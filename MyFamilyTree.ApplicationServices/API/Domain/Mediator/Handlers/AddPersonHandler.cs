

using AutoMapper;
using MediatR;
using MyFamilyTree.ApplicationServices.API.Domain.Mediator.RequestResponses;
using MyFamilyTree.ApplicationServices.API.Domain.Models;
using MyFamilyTree.DataAccess.CQRS.Commands;

using Person = MyFamilyTree.ApplicationServices.API.Domain.Models.Person;

namespace MyFamilyTree.ApplicationServices.API.Domain.Mediator.Handlers
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
            var person = this.mapper.Map<DataAccess.Entities.Person>(request);
            var command = new AddPersonCommand() { Parameter = person };  
            var personfromdb = await commandExecutor.ExecuteAsync(command);
            return new AddPersonResponse()
            {
                Data = this.mapper.Map<Person>(personfromdb),
            };
        }
    }
}
