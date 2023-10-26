using Microsoft.EntityFrameworkCore;
using MyFamilyTree.DataAccess.Entities;

namespace MyFamilyTree.DataAccess.CQRS.Queries
{
    public class GetPersonQuery : QueryBase<Person>
    {
        public int Id { get; set; }
        public async override Task<Person> ExecuteAsync(PeopleCollectionDbContext context)
        {
            var person = await context.PeopleCollection.FirstOrDefaultAsync(x=>x.Id==this.Id);
            
            return person;
        }
    }
}
