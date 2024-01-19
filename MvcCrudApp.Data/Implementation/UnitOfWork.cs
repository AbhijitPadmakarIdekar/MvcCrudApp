using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MvcCrudApp.Data.Context;
using MvcCrudApp.Domain.Repository;

namespace MvcCrudApp.Data.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private bool _disposed = false;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            User = new UserRepository(dbContext);
        }

        public IUserRepository User { get; set; }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
