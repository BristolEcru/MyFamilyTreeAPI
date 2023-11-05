

using MediatR;

namespace MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.GetUser
{
    public class GetUserRequest : IRequest<GetUserResponse>
    {
        public string UserName { get; set; }
       
    }
}
