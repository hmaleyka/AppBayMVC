using AppBay.Core.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBay.DAL.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity, new ()
    {
        Task<IQueryable<T>> GetAllAsync();
        Task<T> GetById(int id);
        Task Create (T entity);
        void Update (T entity);
        void Delete (T entity);
        Task SaveChanges();
    }
}
