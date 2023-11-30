using AutoMapper;
using MediatR;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.GetPersonById;
using MyFamilyTree.ApplicationServices.ModelsDto;
using MyFamilyTree.Domain.CQRS.Queries;
using MyFamilyTree.Domain.CQRS.Queries.QueryManagement;

namespace MyFamilyTree.ApplicationServices.Mediator.Handlers
{
    public class GetPersonByIdHandler : IRequestHandler<GetPersonByIdRequest, GetPersonByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetPersonByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetPersonByIdResponse> Handle(GetPersonByIdRequest request, CancellationToken cancellationToken)
        {
            var id = request.Id;

            var query = new GetPersonByIdQuery
            {
                Id = request.Id
            };

            var person = await queryExecutor.Execute(query);

            var mappedtoDomainperson = mapper.Map<CreateUserDto>(person);

            var response = new GetPersonByIdResponse() { Data = mappedtoDomainperson };

            return response;

        }
    }
}
