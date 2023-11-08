using MediatR;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.Bases;
using MyFamilyTree.Domain.Entities;

namespace MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.GetPeople
{
    public class GetPeopleRequest : RequestBase, IRequest<GetPeopleResponse>
    {
       
    }

}
