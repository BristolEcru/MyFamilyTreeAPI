

using MediatR;
using MyFamilyTreeAPI.Controllers;

namespace MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.DeletePerson
{
    public class DeletePersonRequest : IRequest<DeletePersonResponse>
    {
        public int Id { get; set; }
    }
}
