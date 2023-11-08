using AutoMapper;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.AddPerson;
using MyFamilyTree.ApplicationServices.ModelsDto;
using MyFamilyTree.Domain.CQRS.Queries;

namespace MyFamilyTree.ApplicationServices.Mapping
{
    public class PeopleProfile : Profile
    {
        public PeopleProfile()
        {
            this.CreateMap<AddPersonRequest, Domain.Entities.Person>();

            this.CreateMap<Domain.Entities.Person, PersonDto>();

            this.CreateMap<Domain.Entities.Person, GetPersonByIdQuery>();
            this.CreateMap<PersonDto, Domain.Entities.Person>();

        }
    }
}

