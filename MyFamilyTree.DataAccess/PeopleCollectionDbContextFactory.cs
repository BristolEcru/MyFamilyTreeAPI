
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MyFamilyTree.DataAccess
{
    public class PeopleCollectionDbContextFactory : IDesignTimeDbContextFactory <PeopleCollectionDbContext>
    {

        public PeopleCollectionDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder =  new DbContextOptionsBuilder<PeopleCollectionDbContext>();
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MyFamilyTreeDb;Integrated Security=True;Trust Server Certificate=False");
            return new PeopleCollectionDbContext(optionsBuilder.Options);
        }  
    }
    
}
