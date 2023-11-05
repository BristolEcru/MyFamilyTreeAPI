using Microsoft.EntityFrameworkCore;
using MyFamilyTree.Domain.Entities;
using MyFamilyTree.Domain.Interfaces;

namespace MyFamilyTree.Domain.Repositories
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        protected readonly PeopleCollectionDbContext context;
        private DbSet<T> entities;

        public Repository(PeopleCollectionDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();

        }
       public  Task<List<T>> GetAll()
        {
            return entities.ToListAsync();
        }

       public Task <T> GetById(int id)
        {
            return entities.SingleOrDefaultAsync(x => x.Id == id);
        }

        public Task Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Add(entity);
           return context.SaveChangesAsync();
        }

        public Task Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Update(entity);
          return  context.SaveChangesAsync();
        }
        public async Task DeleteById(int id)
        {
            T entity = await entities.SingleOrDefaultAsync(s => s.Id == id);
            entities.Remove(entity);
            context.SaveChangesAsync();
        }
    }

}
  