﻿using AutoMapper;
using MyFamilyTree.ApplicationServices.API.Domain.Mediator.RequestResponses;

namespace MyFamilyTree.ApplicationServices.Mapping
{
    public class PeopleProfile : Profile
    {
        public PeopleProfile()
        {
            this.CreateMap<AddPersonRequest, DataAccess.Entities.Person>();

            this.CreateMap<DataAccess.Entities.Person, API.Domain.Models.Person>()
                .ForMember(x => x.Id, y => y.MapFrom(y => y.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name));
        }
    }
}

