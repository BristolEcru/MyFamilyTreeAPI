using AutoMapper;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.AddPerson;
using MyFamilyTree.ApplicationServices.ModelsDto;

namespace MyFamilyTree.ApplicationServices.Mapping
{
    public class PeopleProfile : Profile
    {
        public PeopleProfile()
        {
            this.CreateMap<AddPersonRequest, Domain.Entities.Person>();

            this.CreateMap<Domain.Entities.Person, PersonDto>();
               
        }
    }
}

