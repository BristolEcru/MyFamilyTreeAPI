using Microsoft.EntityFrameworkCore.Migrations.Operations;
using MyFamilyTree.Domain.Entities;


namespace MyFamilyTree.Domain.Interfaces
{
    public interface IRepository<T> where T : EntityBase
    {

        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task DeleteById(int id);
        Task Update(T entity);
        Task Insert(T entity);

    }
}
