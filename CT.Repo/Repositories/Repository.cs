using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CT.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CT.Repo.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly CollectionTrackerContext _context;
        private DbSet<T> _entities;

        public Repository(CollectionTrackerContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> Get(int id)
        {
            return await _entities.SingleOrDefaultAsync<T>(e => e.Id == id);
        }

        public async Task Insert(T entity)
        {
            _ = entity ?? throw new ArgumentNullException("entity");
            entity.Id = 0;
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _ = entity ?? throw new ArgumentNullException("entity");
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _ = entity ?? throw new ArgumentNullException("entity");
            _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public void Remove(T entity)
        {
            _ = entity ?? throw new ArgumentNullException("entity");
            _entities.Remove(entity);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
