

using Microsoft.EntityFrameworkCore;
using MyFamilyTree.Domain.CQRS.Commands.CommandManagement;
using MyFamilyTree.Domain.CQRS.Queries;
using MyFamilyTree.Domain.Entities;

namespace MyFamilyTree.Domain.CQRS.Commands
{
    public class DeletePersonCommand : CommandBase<Person, Person>
    {

     
        public override async Task<Person> Execute(PeopleCollectionDbContext context)
        {
            context.PeopleCollection.Remove(this.Parameter);

            await context.SaveChangesAsync();

            return this.Parameter;


        }
    }
}
