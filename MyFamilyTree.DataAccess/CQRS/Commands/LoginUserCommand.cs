using Microsoft.EntityFrameworkCore;
using MyFamilyTree.Domain.CQRS.Commands.CommandManagement;
using MyFamilyTree.Domain.Entities;

namespace MyFamilyTree.Domain.CQRS.Commands
{
    public class LoginUserCommand : CommandBase<User, User>
    {
        public override async Task<User> Execute(PeopleCollectionDbContext context)
        {

            var username = Parameter.Username;
            var passwordhash = Parameter.PasswordHash;

            var user = await context.UsersCollection.FirstOrDefaultAsync(x => x.Username == username);
            if (user != null)
            {
                if (user.PasswordHash == passwordhash) 
                return user;
            }

            return Parameter;
        }
    }
}
