using AppBay.Core.Entities.Entity;
using AppBay.DAL.Context;
using AppBay.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBay.DAL.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly AppDbContext _dbcontext;
        private readonly DbSet<T> _table;

        public Repository(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
            _table = _dbcontext.Set<T>();
        }

        public DbSet<T> Table => _dbcontext.Set<T>();
        public async Task Create(T entity)
        {
          await _table.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            IQueryable<T> features = _table;
            return features;
        }

        public async Task<T> GetById(int id)
        {
            return await _table.FindAsync(id);
        }

        public async Task SaveChanges()
        {
            await _dbcontext.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _table.Update(entity);
        }
    }
}
