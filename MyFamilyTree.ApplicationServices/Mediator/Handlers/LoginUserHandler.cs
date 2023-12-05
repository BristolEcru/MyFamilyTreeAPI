

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using MyFamilyTree.ApplicationServices.Jwt;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.CreateUser;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.LoginUser;
using MyFamilyTree.ApplicationServices.ModelsDto;
using MyFamilyTree.Domain.CQRS.Commands;
using MyFamilyTree.Domain.CQRS.Commands.CommandManagement;
using MyFamilyTree.Domain.CQRS.Queries;
using MyFamilyTree.Domain.CQRS.Queries.QueryManagement;
using MyFamilyTree.Domain.Entities;

namespace MyFamilyTree.ApplicationServices.Mediator.Handlers
{
    public class LoginUserHandler : IRequestHandler<LoginUserRequest, LoginUserResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly IPasswordHasher<User> passwordHasher;
        private readonly IJwtService jwtService;

        public LoginUserHandler(IMapper mapper, IQueryExecutor queryExecutor, IPasswordHasher<User> passwordHasher, IJwtService jwtService)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.passwordHasher = passwordHasher;
            this.jwtService = jwtService;
        }
        public async Task<LoginUserResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {
            var loginguser = mapper.Map<User>(request);
            loginguser.PasswordHash = passwordHasher.HashPassword(loginguser, request.Password);

            var query = new GetUserQuery { Username = request.Username };

            var userfromdb = await queryExecutor.Execute(query);

            if(string.IsNullOrEmpty(request.Password) || userfromdb == null)
            {
                return new LoginUserResponse
                {
                    Error = new RequestsAndResponses.Bases.ErrorModel("Wrong username or password")
                };
            }

            if(passwordHasher.VerifyHashedPassword(userfromdb, userfromdb.PasswordHash, request.Password)==PasswordVerificationResult.Failed)
            {
                return new LoginUserResponse
                {
                    Error = new RequestsAndResponses.Bases.ErrorModel("Wrong username or password")
                };
            }

            var response = new LoginUserResponse()
            {
                Data = mapper.Map<AuthResponseDto>(userfromdb)
            };
            response.Data.JwtToken = jwtService.GenerateJwtToken(userfromdb);

            return response;
        }
    }
}
