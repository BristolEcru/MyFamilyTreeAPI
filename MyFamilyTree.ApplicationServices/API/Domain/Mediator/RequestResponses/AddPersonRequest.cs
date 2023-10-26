
using MediatR;
using MyFamilyTree.DataAccess.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyFamilyTree.ApplicationServices.API.Domain.Mediator.RequestResponses
{
    public class AddPersonRequest: IRequest<AddPersonResponse>
    {
        public string Name { get; set; }


        public string? Surname { get; set; }

        public string? Description { get; set; }
        public EnumGender? PersonGender { get; set; }
    }
}
