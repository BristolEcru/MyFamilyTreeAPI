

using AutoMapper;
using MediatR;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.GetAllUsers;
using MyFamilyTree.ApplicationServices.ModelsDto;
using MyFamilyTree.Domain.CQRS.Queries;
using MyFamilyTree.Domain.CQRS.Queries.QueryManagement;

namespace MyFamilyTree.ApplicationServices.Mediator.Handlers
{
    public class GetUsersHandler : IRequestHandler<GetUsersRequest, GetUsersResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryexecutor;

        public GetUsersHandler(IMapper mapper, IQueryExecutor queryexecutor)
        {
            this.mapper = mapper;
            this.queryexecutor = queryexecutor;
        }

        public async Task<GetUsersResponse> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            var query = new GetUsersQuery();
            var lisofusersfromdb = queryexecutor.Execute(query);
            var mappedUsers = mapper.Map<List<UserDto>>(lisofusersfromdb);

            var response = new GetUsersResponse { Data = mappedUsers };
            return response;
        }
    }
}
