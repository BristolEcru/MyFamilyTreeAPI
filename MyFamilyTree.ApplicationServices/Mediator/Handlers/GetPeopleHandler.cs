

using AutoMapper;
using MediatR;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.GetPeople;
using MyFamilyTree.ApplicationServices.ModelsDto;
using MyFamilyTree.Domain.CQRS.Queries;
using MyFamilyTree.Domain.CQRS.Queries.QueryManagement;


namespace MyFamilyTree.ApplicationServices.Mediator.Handlers
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

            var people = await queryExecutor.Execute(query);

            var mappedPeople = mapper.Map<List<PersonDto>>(people);

            var response = new GetPeopleResponse()
            {
                Data = mappedPeople
            };

            return response;
        }
    }
}
