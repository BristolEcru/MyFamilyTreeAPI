using MediatR;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.Bases;

namespace MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.GetAllUsers
{
    public class GetUsersRequest : RequestBase, IRequest<GetUsersResponse>
    {
    }
}