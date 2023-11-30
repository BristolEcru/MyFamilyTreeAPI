using Microsoft.EntityFrameworkCore;
using MyFamilyTree.Domain;
using MyFamilyTree.Domain.CQRS.Commands.CommandManagement;
using MyFamilyTree.Domain.Entities;

namespace MyFamilyTree.ApplicationServices.Mediator.Handlers
{
    public class EditPersonCommand : CommandBase<Person, Person>
    {
        public Person Parameter { get; set; }

        public override async Task<Person> Execute(PeopleCollectionDbContext context)
        {
            var personIdToUpdate = Parameter.Id;
            var existingPerson = await context.PeopleCollection.FirstOrDefaultAsync(p => p.Id == personIdToUpdate);

            if (existingPerson != null)
            {
                context.Entry(existingPerson).CurrentValues.SetValues(Parameter);
                await context.SaveChangesAsync();
            }

            return existingPerson;
        }
    }
}