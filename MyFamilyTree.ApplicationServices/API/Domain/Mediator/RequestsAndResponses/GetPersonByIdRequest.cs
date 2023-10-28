

using MediatR;
using MyFamilyTree.ApplicationServices.API.Domain.Models;

namespace MyFamilyTree.ApplicationServices.API.Domain.Mediator.RequestResponses
{
    public class GetPersonByIdRequest : IRequest<GetPersonByIdResponse>
    {
        public int Id { get; set; }

        public GetPersonByIdRequest(int id)
        {
            Id = id;
        }

    }
}
