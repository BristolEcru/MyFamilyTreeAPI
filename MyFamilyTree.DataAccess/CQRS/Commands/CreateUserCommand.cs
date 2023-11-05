

using MyFamilyTree.Domain.CQRS.Commands.CommandManagement;
using MyFamilyTree.Domain.Entities;

namespace MyFamilyTree.Domain.CQRS.Commands
{
    public class CreateUserCommand : CommandBase<User, User>
    {
        public override async Task<User> Execute(PeopleCollectionDbContext context)
        {
            await context.UsersCollection.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
