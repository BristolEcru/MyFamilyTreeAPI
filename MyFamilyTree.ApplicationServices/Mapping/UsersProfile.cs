

using AutoMapper;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.CreateUser;
using MyFamilyTree.ApplicationServices.ModelsDto;
using MyFamilyTree.Domain.Entities;

namespace MyFamilyTree.ApplicationServices.Mapping
{
    public class UsersProfile : Profile
    {
        public UsersProfile() 
        {

            CreateMap<User, UserDto>();
            CreateMap<User, CreateUserDto>();
            CreateMap<User, CreateUserRequest>();
            CreateMap<CreateUserRequest, UserDto>();
            CreateMap<CreateUserRequest, User>();

            CreateMap<CreateUserDto, UserDto>();

        }
    }
}
