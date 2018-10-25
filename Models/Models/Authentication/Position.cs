using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Position")]
    public class Position: Identity
    {
        [MaxLength(20)]
        public virtual string Code { get; set; }
        [MaxLength(128)]
        public virtual string Name { get; set; }
    }
}
