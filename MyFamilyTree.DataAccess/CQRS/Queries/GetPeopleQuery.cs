

using Microsoft.EntityFrameworkCore;
using MyFamilyTree.DataAccess.Entities;

namespace MyFamilyTree.DataAccess.CQRS.Queries
{
    public class GetPeopleQuery : QueryBase<List<Person>>
    {
        public override Task<List<Person>> ExecuteAsync(PeopleCollectionDbContext context)
        {
             return context.PeopleCollection.ToListAsync();

        }
    }
}
