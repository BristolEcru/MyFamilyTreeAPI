
using Microsoft.EntityFrameworkCore;
using MyFamilyTree.Domain.CQRS.Queries.QueryManagement;
using MyFamilyTree.Domain.Entities;

namespace MyFamilyTree.Domain.CQRS.Queries
{
    public class GetUsersQuery: QueryBase<List<User>>
    {
        public override async Task<List<User>> Execute(PeopleCollectionDbContext context)
        {
            return await context.UsersCollection.ToListAsync();
        }
    
    }
}
