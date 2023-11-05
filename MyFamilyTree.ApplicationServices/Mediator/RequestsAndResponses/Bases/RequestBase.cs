

using MyFamilyTree.Domain.Entities;
using System.Security.Claims;

namespace MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.Bases
{
    public abstract class RequestBase
    {
        public User user { get; set; }

        public RequestBase()
        {
            var claims = new[] {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };
        }
    }
}
