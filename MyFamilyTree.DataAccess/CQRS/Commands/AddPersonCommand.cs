
using MyFamilyTree.Domain.CQRS.Commands.CommandManagement;
using MyFamilyTree.Domain.Entities;

namespace MyFamilyTree.Domain.CQRS.Commands
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
