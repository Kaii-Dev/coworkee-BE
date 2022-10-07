using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Coworkee.Data;

namespace Infrastructure
{
    public class DbFactory : IDisposable
    {
        private bool _disposed;
        private readonly Func<ApplicationDbContext> _dbContextFactory;
        private DbContext _dbContext;
        public DbContext DbContext => _dbContext ??= _dbContextFactory.Invoke();

        public DbFactory(Func<ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public void Dispose()
        {
            if (!_disposed && _dbContext != null)
            {
                _disposed = true;
                _dbContext.Dispose();
            }
        }
    }
}
