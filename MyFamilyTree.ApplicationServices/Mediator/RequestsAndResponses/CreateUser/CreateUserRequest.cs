

using Azure.Identity;
using MediatR;
using MyFamilyTree.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.CreateUser
{

    public class CreateUserRequest : IRequest<CreateUserResponse>
    {
        public EnumRole Role { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        //public string FirstName { get; set; }
        //public string LastName { get; set; }

        //[RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        //[StringLength(30)]
        //public string PhoneNumber { get; set; }



    }

}

