using Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Profile")]
    public class Profile: Identity
    {
        public Profile()
        {
            Code = Guid.NewGuid().ToString().ToUpper();
        }

        [MaxLength(128)]
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual string Code { get; set; }
        public virtual string Firstname { get; set; }
        public virtual string Lastname { get; set; }
        public virtual string Question { get; set; }
        public virtual string EMail { get; set; }
        public virtual EProfile EProfile { get; set; }
        public virtual Department Department { get; set; }
        public virtual Company Company { get; set; }
        public virtual Position Position { get; set; }
        public virtual ICollection<Registers> Registers { get; set; }
    }
}
