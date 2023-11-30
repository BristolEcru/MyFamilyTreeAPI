

using AutoMapper;
using MediatR;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.CreateUser;
using MyFamilyTree.ApplicationServices.ModelsDto;
using MyFamilyTree.Domain.CQRS.Commands;
using MyFamilyTree.Domain.CQRS.Commands.CommandManagement;
using MyFamilyTree.Domain.Entities;
using MyFamilyTree.Domain.Entities.Enums;
using System.Data;

namespace MyFamilyTree.ApplicationServices.Mediator.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IPasswordHasher<User> passwordHasher;

        public CreateUserHandler(IMapper mapper, ICommandExecutor commandExecutor, IPasswordHasher<User> passwordHasher)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.passwordHasher = passwordHasher;
        }
        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var newuser = mapper.Map<User>(request);
            newuser.PasswordHash = passwordHasher.HashPassword(newuser,request.Password);
            newuser.Role = EnumRole.User;
            var command =  new CreateUserCommand { Parameter = newuser };
            var userfromdb = await commandExecutor.Execute(command);
            var response =  new CreateUserResponse() 
            { 
                Data = mapper.Map<UserDto>(userfromdb) 
            };
            return response;
        }
    }
}
