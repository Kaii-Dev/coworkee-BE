using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Coworkee.Model;

namespace Infrastructure.Repositories.ApplicationContext.Music
{
    public interface IMusicRepository : IRepository<Coworkee.Model.Music>
    {
        public List<Coworkee.Model.Music> ShowMusic(Coworkee.Model.Music model);
        public bool IsValidName(string id, string name);
        public List<Coworkee.Model.Music> ListCombobox();

    }
}
