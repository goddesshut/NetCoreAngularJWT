using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Enterprise")]
    public class Enterprise: Identity
    {
        [MaxLength(20)]
        public virtual string Code { get; set; }

        [MaxLength(128)]
        public virtual string Name { get; set; }

        public virtual IList<Company> Companys { get; set; }
    }
}
