using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    [Table("Department")]
    public class Department: Identity
    {
        public Department()
        {
            Child = new HashSet<Department>();
            Profiles = new HashSet<Profile>();
        }

        [MaxLength(128)]
        public virtual string Code { get; set; }
        [MaxLength(128)]
        public virtual string Name { get; set; }
        public virtual Guid? Parent { get; set; }
        public virtual int ReversionNumber { get; set; }

        public virtual ICollection<Department> Child { get; set; }
        public virtual ICollection<Profile> Profiles { get; set; }
    }
}
