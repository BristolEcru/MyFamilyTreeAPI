using MediatR;

namespace MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.GetAllUsers
{
    public class GetUsersRequest :IRequest<GetUsersResponse>
    {
    }
}