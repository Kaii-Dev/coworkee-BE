using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IRepository<T> where T: class
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        Task<T> FindAsync(string id);
    }
}
