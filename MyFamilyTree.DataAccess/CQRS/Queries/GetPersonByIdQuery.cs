using Microsoft.EntityFrameworkCore;
using MyFamilyTree.DataAccess.CQRS.Queries.QueryManagement;
using MyFamilyTree.DataAccess.Entities;

namespace MyFamilyTree.DataAccess.CQRS.Queries
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
