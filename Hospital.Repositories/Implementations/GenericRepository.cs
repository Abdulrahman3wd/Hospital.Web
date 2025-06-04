using Hospital.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repositories.Implementations
{
    public class GenericRepository<T> : IDisposable, IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<T> dbset;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            dbset = _context.Set<T>();
        }
        public void Add(T entity)
        {
            dbset.Add(entity);
        }

        public async Task<T> AddAsync(T entity)
        {
            await dbset.AddAsync(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                dbset.Attach(entity);            
            }
            dbset.Remove(entity);
        }

        public async  Task<T> DeleteAsync(T entity)
        {
            if ( _context.Entry(entity).State == EntityState.Detached)
            {
                dbset.Attach(entity);
            }
            dbset.Remove(entity);

            return entity;

        }

        private bool _disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                    _context.Dispose();
            }

            this._disposed = true;

        }

        public IEnumerable<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = dbset;
            if (filter is not null)
            {
                query = query.Where(filter);                
            }

            foreach (var includeProperty in 
                includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);                
            }

            if (orderBy is not null)           
                return orderBy(query).ToList();

            else 
                return query.ToList();          
            
        }

        public T GetById(object id)
        {
             return dbset.Find(id);       
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await dbset.FindAsync(id);
        }

        public void Update(T entity)
        {
            dbset.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

        }
         
        public async Task<T> UpdateAsync(T entity)
        {
            dbset.Attach(entity);

            _context.Entry(entity).State = EntityState.Modified;

            return entity;

        }
    }
}
