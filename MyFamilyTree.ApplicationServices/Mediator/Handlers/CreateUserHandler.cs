

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.CreateUser;
using MyFamilyTree.ApplicationServices.ModelsDto;
using MyFamilyTree.Domain.CQRS.Commands;
using MyFamilyTree.Domain.CQRS.Commands.CommandManagement;
using MyFamilyTree.Domain.Entities;

namespace MyFamilyTree.ApplicationServices.Mediator.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public CreateUserHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }
        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var usertodb = mapper.Map<User>(request);
            var command =  new CreateUserCommand { Parameter = usertodb };
            var userfromdb = await commandExecutor.Execute(command);
            var response =  new CreateUserResponse() 
            { 
                Data = mapper.Map<UserDto>(userfromdb) 
            };
            return response;
        }
    }
}
