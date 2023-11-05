
using MediatR;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.BaseClasses;
using MyFamilyTree.ApplicationServices.ModelsDto;

namespace MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.GetAllPeople
{
    public class GetPeopleResponse : ResponseBase<List<PersonDto>>
    {

    }
}