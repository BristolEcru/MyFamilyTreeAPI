

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.CreateUser;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.LoginUser;
using MyFamilyTree.ApplicationServices.ModelsDto;
using MyFamilyTree.Domain.CQRS.Commands;
using MyFamilyTree.Domain.CQRS.Commands.CommandManagement;
using MyFamilyTree.Domain.Entities;

namespace MyFamilyTree.ApplicationServices.Mediator.Handlers
{
    public class LoginUserHandler : IRequestHandler<LoginUserRequest, LoginUserResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IPasswordHasher<User> passwordHasher;

        public LoginUserHandler(IMapper mapper, ICommandExecutor commandExecutor, IPasswordHasher<User> passwordHasher)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.passwordHasher = passwordHasher;
        }
        public async Task<LoginUserResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {
            var loginguser = mapper.Map<User>(request);
            loginguser.PasswordHash = passwordHasher.HashPassword(loginguser, request.Password);
            var command = new LoginUserCommand { Parameter = loginguser };
            var userfromdb = await commandExecutor.Execute(command);
            var response = new LoginUserResponse()
            {
                Data = mapper.Map<UserDto>(userfromdb)
            };


            return response;
        }
    }
}
