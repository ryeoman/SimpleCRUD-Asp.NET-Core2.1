using Medico.Challange.DL;
using Medico.Challange.DL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medico.Challange.Services.Repositories
{
    public class Repository<T> : IDisposable, IRepository<T> where T : class
    {
        private readonly ApplicationMainDbContext _context;

        public Repository(ApplicationMainDbContext context)
        {
            this._context = context;
        }

        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            _context.Entry(entity).GetDatabaseValues();
            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            await _context.Entry(entity).GetDatabaseValuesAsync();
            return entity;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            if (_context == null)
                return;

            _context.Dispose();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public T GetById(string id)
        {
            return _context.Set<T>().Find(id);
        }

        public async Task<T> GetByIdAsync(string id)
        {
            var entity = await _context.Set<T>().FindAsync(id);

            return entity;
        }

        public ApplicationMainDbContext GetContext()
        {
            return _context;
        }

        public IEnumerable<T> ListAll()
        {
            return _context.Set<T>().AsEnumerable();
        }

        public async Task<List<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public void Update(T entity)
        {
            var entry = _context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                _context.Set<T>().Attach(entity);
                entry = _context.Entry(entity);
            }
            entry.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var entry = _context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                _context.Set<T>().Attach(entity);
                entry = _context.Entry(entity);
            }
            entry.State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
