
using Microsoft.EntityFrameworkCore;
using MyFamilyTree.Domain.CQRS.Queries.QueryManagement;
using MyFamilyTree.Domain.Entities;

namespace MyFamilyTree.Domain.CQRS.Queries
{
    public class GetUserQuery : QueryBase<User>
    {
        public string Username { get; set; }
        public override async Task<User> Execute(PeopleCollectionDbContext context)
        {
            return await context.UsersCollection.FirstOrDefaultAsync(x=>x.Username == this.Username);
        }
         
    }
}
