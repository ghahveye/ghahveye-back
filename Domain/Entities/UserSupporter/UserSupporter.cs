using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Entities
{
    public class UserSupporter
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public Guid SupporterId { get; set; }
        public DateTime CreateDate { get; set; }
        [ForeignKey("User")]
        public virtual ApplicationUser User { get; set; }
        [ForeignKey("SupporterId")]
        public virtual List<Supporter> Supporter { get; set; }
    }
}
