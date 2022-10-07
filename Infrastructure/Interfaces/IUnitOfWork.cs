using Infrastructure.Repositories.ApplicationContext.Music;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {
        public IMusicRepository MusicRepository { get; }
        Task<int> CommitAsync();
        int Commit();
    }
}
