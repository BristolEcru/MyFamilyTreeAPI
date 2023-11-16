

using MediatR;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.Bases;

namespace MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.GetUser
{
    public class GetUserRequest : RequestBase, IRequest<GetUserResponse>
    {
        public string Username { get; set; }
       
    }
}
