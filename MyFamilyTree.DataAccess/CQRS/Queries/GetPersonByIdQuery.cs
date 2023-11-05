using Microsoft.EntityFrameworkCore;
using MyFamilyTree.Domain.CQRS.Queries.QueryManagement;
using MyFamilyTree.Domain.Entities;

namespace MyFamilyTree.Domain.CQRS.Queries
{
    public class GetPersonByIdQuery : QueryBase<Person>
    {
        public int Id { get; set; }
        public override async Task<Person> Execute (PeopleCollectionDbContext context)
        {
            var person = await context.PeopleCollection.FirstOrDefaultAsync(x=>x.Id==this.Id);
            
            return person;
        }
    }
}
