using AutoMapper;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.AddPerson;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.EditPerson;
using MyFamilyTree.ApplicationServices.ModelsDto;
using MyFamilyTree.Domain.CQRS.Queries;
using MyFamilyTree.Domain.Entities;

namespace MyFamilyTree.ApplicationServices.Mapping
{
    public class PeopleProfile : Profile
    {
        public PeopleProfile()
        {
            this.CreateMap<AddPersonRequest, Person>();

            this.CreateMap<EditPersonRequest, Person>();


            this.CreateMap<Person, CreateUserDto>();
      

            this.CreateMap<Person, GetPersonByIdQuery>();

            this.CreateMap<CreateUserDto, Person>();

        }
    }
}

