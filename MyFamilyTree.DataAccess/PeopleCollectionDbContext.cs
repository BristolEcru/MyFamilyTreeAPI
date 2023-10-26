using Microsoft.EntityFrameworkCore;
using MyFamilyTree.DataAccess.Entities;


namespace MyFamilyTree.DataAccess
{
    public class PeopleCollectionDbContext : DbContext
    {
        public PeopleCollectionDbContext(DbContextOptions<PeopleCollectionDbContext> opt):base (opt) 
        {

        }

        public DbSet<Person> PeopleCollection { get; set; }
     
    }
}
