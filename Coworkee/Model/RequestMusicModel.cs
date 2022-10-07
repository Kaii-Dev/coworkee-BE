using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Coworkee.Model
{
    public class RequestMusicModel
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Link { get; set; }
        public bool Active { get; set; }
        public string Description { get; set; }


    }
}
