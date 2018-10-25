using Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Application")]
    public class Application : Identity
    {
        [MaxLength(40)]
        public virtual string HashCode { get; set; }

        [MaxLength(20)]
        public virtual string Code { get; set; }

        [MaxLength(128)]
        public virtual string Name { get; set; }

        public virtual EApplication ECode { get; set; }

        public virtual int Sequence { get; set; }

        public virtual ICollection<Registers> Registers { get; set; }
    }
}
