using Microsoft.EntityFrameworkCore;
using MyFamilyTree.Domain.Entities;


namespace MyFamilyTree.Domain
{
    public class PeopleCollectionDbContext : DbContext
    {
        public PeopleCollectionDbContext(DbContextOptions<PeopleCollectionDbContext> opt):base (opt) 
        {

        }

        public DbSet<Person> PeopleCollection { get; set; }
        public DbSet<User> UsersCollection { get;set; }
     
    }
}
