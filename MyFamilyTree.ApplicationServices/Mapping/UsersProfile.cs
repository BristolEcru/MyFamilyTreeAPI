

using AutoMapper;
using MyFamilyTree.ApplicationServices.ModelsDto;
using MyFamilyTree.Domain.Entities;

namespace MyFamilyTree.ApplicationServices.Mapping
{
    public class UsersProfile : Profile
    {
        public UsersProfile() 
        {
            CreateMap<User, UserDto>();
        }
    }
}
