

using MyFamilyTree.Domain.Entities;
using MyFamilyTree.Domain.Entities.Enums;
using System.Security.Claims;

namespace MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.Bases
{
    public abstract class RequestBase
    {
        public string usernamefromclaim { get; set; }
        public string userrolefromclaim { get; set; }
        public RequestBase()
        {
            usernamefromclaim = ClaimTypes.Name;

            userrolefromclaim = ClaimTypes.Role;
        }
    }
}
