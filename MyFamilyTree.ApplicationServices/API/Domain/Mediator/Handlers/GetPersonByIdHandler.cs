using AutoMapper;
using MediatR;
using MyFamilyTree.ApplicationServices.API.Domain.Mediator.RequestResponses;
using MyFamilyTree.ApplicationServices.API.Domain.Models;
using MyFamilyTree.DataAccess.CQRS.Queries;
using MyFamilyTree.DataAccess.CQRS.Queries.QueryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFamilyTree.ApplicationServices.API.Domain.Mediator.Handlers
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
                Id = id
            };

            var person =  await queryExecutor.Execute(query);

           var mappedtoDomainperson = mapper.Map<Person>(person);

            var response = new GetPersonByIdResponse() { Data = mappedtoDomainperson };

            return response;

        }  
    }
}
