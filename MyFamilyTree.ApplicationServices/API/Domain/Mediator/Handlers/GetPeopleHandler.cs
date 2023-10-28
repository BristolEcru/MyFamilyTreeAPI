

using AutoMapper;
using MediatR;
using MyFamilyTree.ApplicationServices.API.Domain.Mediator.RequestResponses;
using MyFamilyTree.DataAccess.CQRS.Queries;
using MyFamilyTree.DataAccess.CQRS.Queries.QueryManagement;
using MyFamilyTree.DataAccess.Entities;


namespace MyFamilyTree.ApplicationServices.API.Domain.Mediator.Handlers
{
    public class GetPeopleHandler : IRequestHandler<GetPeopleRequest, GetPeopleResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetPeopleHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetPeopleResponse> Handle(GetPeopleRequest request, CancellationToken cancellationToken)
        {
            var query = new GetPeopleQuery();

            var people = await this.queryExecutor.Execute(query);

            var mappedPeople = mapper.Map<List<Domain.Models.Person>>(people);

            var response = new GetPeopleResponse()
            {
                Data = mappedPeople
            };

            return response;
        }
    }
}
