using Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public abstract class Identity
    {
        public Identity()
        {
            CreateDate = DateTime.Now;
            UpdateDate = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID", Order = 1)]
        public virtual int Id { get; set; }

        [MaxLength(128)]
        public virtual string CreateBy { get; set; }
        public virtual DateTime? CreateDate { get; set; }

        [MaxLength(128)]
        public virtual string UpdateBy { get; set; }
        public virtual DateTime? UpdateDate { get; set; }

        public virtual bool IsActive { get; set; }
    }
}
