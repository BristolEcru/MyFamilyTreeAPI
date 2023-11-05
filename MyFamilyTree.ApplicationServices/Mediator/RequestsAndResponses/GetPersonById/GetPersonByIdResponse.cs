using MediatR;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.BaseClasses;
using MyFamilyTree.ApplicationServices.ModelsDto;

namespace MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.GetPersonById
{
    public class GetPersonByIdResponse : ResponseBase<PersonDto>
    {
    }
}