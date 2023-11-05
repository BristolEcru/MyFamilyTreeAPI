

using Microsoft.EntityFrameworkCore;
using MyFamilyTree.Domain.CQRS.Queries.QueryManagement;
using MyFamilyTree.Domain.Entities;

namespace MyFamilyTree.Domain.CQRS.Queries
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
