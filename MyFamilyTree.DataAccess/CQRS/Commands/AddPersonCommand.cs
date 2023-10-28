
using MyFamilyTree.DataAccess.CQRS.Commands.CommandManagement;
using MyFamilyTree.DataAccess.Entities;

namespace MyFamilyTree.DataAccess.CQRS.Commands
{
    public class AddPersonCommand : CommandBase<Person, Person>
    {
        public override async Task<Person> Execute(PeopleCollectionDbContext context)
        {
            await context.PeopleCollection.AddAsync(this.Parameter);
           await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
