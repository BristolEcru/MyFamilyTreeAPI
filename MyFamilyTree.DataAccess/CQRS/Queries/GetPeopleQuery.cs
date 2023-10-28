

using Microsoft.EntityFrameworkCore;
using MyFamilyTree.DataAccess.CQRS.Queries.QueryManagement;
using MyFamilyTree.DataAccess.Entities;

namespace MyFamilyTree.DataAccess.CQRS.Queries
{
    public class GetPeopleQuery : QueryBase<List<Person>>
    {
        public override async Task<List<Person>> Execute(PeopleCollectionDbContext context)
        {
            var allpeople = await context.PeopleCollection.ToListAsync();
            return allpeople;
        }
    }
}
