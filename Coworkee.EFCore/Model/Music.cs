using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Coworkee.Model
{
    [Table("NewMusic")]
    public class Music
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("name", TypeName = "varchar(250)")]
        public string Name { get; set; }

        [Required]
        [Column("author", TypeName = "varchar(250)")]
        public string Author { get; set; }

        [Required]
        [Column("link", TypeName = "varchar(250)")]
        public string Link { get; set; }

        [Column("active", TypeName = "boolean")]
        public bool Active { get; set; }

        [Required]
        [Column("description", TypeName = "text")]
        public string Description { get; set; }

        [Column(TypeName = "boolean")]
        public bool Deleted { get; set; }
    }
}


