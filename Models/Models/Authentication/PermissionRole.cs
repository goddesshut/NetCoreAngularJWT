using Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("PermissionRole")]
    public class PermissionRole: Identity
    {
        public virtual string Code { get; set; }
        public virtual string Name { get; set; }
        public virtual EPermissionRole ECode { get; set; }
        public virtual ICollection<Registers> Registers { get; set; }
    }
}
