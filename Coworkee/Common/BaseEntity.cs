using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coworkee.Common
{
    public class BaseEntity : IEntity
    {
        [Key]
        [Column(TypeName = "varchar(18)")]

        public string Id { get; set; }
    }
}
