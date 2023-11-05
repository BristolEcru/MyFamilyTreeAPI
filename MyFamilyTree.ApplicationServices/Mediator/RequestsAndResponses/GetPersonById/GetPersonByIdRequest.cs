

using MediatR;

namespace MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.GetPersonById
{
    public class GetPersonByIdRequest : IRequest<GetPersonByIdResponse>
    {
        public int Id { get; set; }

      
    }
}
