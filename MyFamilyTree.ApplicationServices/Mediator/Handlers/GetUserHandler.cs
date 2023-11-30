

using AutoMapper;
using MediatR;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.GetUser;
using MyFamilyTree.ApplicationServices.ModelsDto;
using MyFamilyTree.Domain.CQRS.Queries;
using MyFamilyTree.Domain.CQRS.Queries.QueryManagement;

namespace MyFamilyTree.ApplicationServices.Mediator.Handlers
{
    public class GetUserHandler : IRequestHandler<GetUserRequest, GetUserResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetUserHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetUserResponse> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            var query = new GetUserQuery { Username = request.Username };

            var userFromDb = await queryExecutor.Execute(query);

            var userDto= mapper.Map<CreateUserDto>(userFromDb);

            var response = new GetUserResponse { Data = userDto };

            return response;

        }
    }
}
