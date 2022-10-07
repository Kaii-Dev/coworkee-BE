using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Coworkee.Common;

namespace Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IHttpContextAccessor _accessor;
        private string CurrentUser => _accessor.HttpContext.User.Identity.Name;
        private readonly DbFactory _dbFactory;
        private DbSet<T> _dbSet;
        protected DbSet<T> DbSet => _dbSet ??= _dbFactory.DbContext.Set<T>();
        protected bool IsUserLoggedIn => !string.IsNullOrEmpty(CurrentUser);
        protected Repository(DbFactory dbFactory, IHttpContextAccessor accessor)
        {
            _dbFactory = dbFactory;
            _accessor = accessor;  
        }


        public void Add(T entity)
        {
            if (typeof(IAuditEntity<T>).IsAssignableFrom(typeof(T)))
            {
                var audit = (IAuditEntity<T>)entity;
                audit.SetCreated(string.IsNullOrEmpty(audit.CreatedBy) ? CurrentUser : audit.CreatedBy, audit.CreatedAt.Year != 1 ? audit.CreatedAt : DateTime.UtcNow);
            }
            DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public async Task<T> FindAsync(string id)
        {
            return await DbSet.FindAsync(id);
        }

        public void Update(T entity)
        {
            if (typeof(IAuditEntity<T>).IsAssignableFrom(typeof(T)))
            {
                var audit = (IAuditEntity<T>)entity;
                audit.SetUpdated(IsUserLoggedIn ? CurrentUser : audit.UpdatedBy, DateTime.UtcNow); 
            }
            DbSet.Update(entity);
        }
    }
}
