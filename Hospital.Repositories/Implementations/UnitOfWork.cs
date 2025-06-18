using Hospital.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork , IDisposable
    {
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IGenericRepository<T> GenericRepository<T>() where T : class
        {
            IGenericRepository<T> repo = new GenericRepository<T>(_dbContext);
            return repo;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        private bool disposed = false;
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);


        }

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;

        }

    }
}
