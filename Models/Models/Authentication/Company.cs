using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Company")]
    public class Company : Identity
    {
        [MaxLength(20)]
        public virtual string Code { get; set; }
        [MaxLength(128)]
        public virtual string Name { get; set; }
        public virtual Enterprise Enterprise { get; set; }
    }
}
