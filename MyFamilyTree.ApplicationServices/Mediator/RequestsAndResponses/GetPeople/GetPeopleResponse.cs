
using MediatR;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.BaseClasses;
using MyFamilyTree.ApplicationServices.ModelsDto;

namespace MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.GetPeople
{
    public class GetPeopleResponse : ResponseBase<List<CreateUserDto>>
    {

    }
}