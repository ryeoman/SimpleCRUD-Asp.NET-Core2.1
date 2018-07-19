using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Medico.Challange.DL.Entities
{
    public class BaseEntity
    {
        [Key]
        public string Id { get; set; }

        [ForeignKey("CreatedApplicationUser")]
        public string CreatedBy { get; set; }
        public virtual ApplicationUser CreatedApplicationUser { get; set; }
        public DateTime? CreatedDate { get; set; }

        [ForeignKey("ModifiedApplicationUser")]
        public string ModifiedBy { get; set; }
        public virtual ApplicationUser ModifiedApplicationUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
