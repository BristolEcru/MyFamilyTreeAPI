

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

        
            CreateMap<User, CreateUserDto>();
            CreateMap<User, CreateUserRequest>();

            CreateMap<CreateUserRequest, CreateUserDto>();
            CreateMap<CreateUserRequest, User>();

            CreateMap<LoginUserRequest, CreateUserDto>();
            CreateMap<LoginUserRequest, User>();
        }
    }
}
