using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Repositories.ApplicationContext.Music
{
    public class MusicRepository : Repository<Coworkee.Model.Music>, IMusicRepository
    {
        public MusicRepository(DbFactory dbFactory, IHttpContextAccessor accessor) :  base(dbFactory, accessor)
        {
        }

        public List<Coworkee.Model.Music> ShowMusic(Coworkee.Model.Music model)
        {
            List<Coworkee.Model.Music> results = DbSet.AsEnumerable().Select(x => new Coworkee.Model.Music
            {
                Id = x.Id,
                Name = x.Name,
                Active = x.Active,
                Description = x.Description,
                Author = x.Author,
                Link = x.Link,

            })
                .OrderBy(x => x.Name).ToList();
            return results;
        }

        public List<Coworkee.Model.Music> ListCombobox()
        {
            return DbSet.Where(x => x.Active).ToList();
        }

        public bool CheckDuplicateName(string name)
        {
            return DbSet.Any(x => x.Name.ToLower().Equals(name.ToLower()));
        }

        public bool CheckNameExitsById(string id, string name)
        {
            return DbSet.Any(x=> string.Equals(x.Name.ToLower(), name.ToLower()) && string.Equals(x.Id,id));
        }

        public bool IsValidName(string id, string name)
        {
            return !CheckDuplicateName(name) || CheckNameExitsById(id, name);
        }
        
    }
}
