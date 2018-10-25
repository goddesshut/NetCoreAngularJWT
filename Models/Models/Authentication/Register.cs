using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Registers")]
    public class Registers: Identity
    {
        public virtual PermissionRole PermissionRole { get; set; }
        public virtual Profile Profile { get; set; }
        public virtual Application Application { get; set; }
    }
}
