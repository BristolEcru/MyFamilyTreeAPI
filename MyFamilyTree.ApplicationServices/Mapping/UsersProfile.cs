

using AutoMapper;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.CreateUser;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.LoginUser;
using MyFamilyTree.ApplicationServices.ModelsDto;
using MyFamilyTree.Domain.Entities;

namespace MyFamilyTree.ApplicationServices.Mapping
{
    public class UsersProfile : Profile
    {
        public UsersProfile() 
        {
            
            CreateMap<User, AuthResponseDto>();

            CreateMap<User, UserDto>();
            CreateMap<User, CreateUserRequest>();

            CreateMap<CreateUserRequest, UserDto>();
            CreateMap<CreateUserRequest, User>();

            CreateMap<LoginUserRequest, UserDto>();
            CreateMap<LoginUserRequest, User>();
        }
    }
}
