using Infrastructure.Interfaces;
using Infrastructure.Repositories.ApplicationContext.Music;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        //khai bao interface
        //phuong thuc commitAsync, commit
        public IMusicRepository MusicRepository { get; }
        private readonly DbFactory _dbFactory;
        public UnitOfWork(DbFactory dbFactory, IMusicRepository musicRepository)
        {
            _dbFactory = dbFactory;
            MusicRepository = musicRepository;
        }
        public int Commit()
        {
            return _dbFactory.DbContext.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return _dbFactory.DbContext.SaveChangesAsync();
        }
    }
}
