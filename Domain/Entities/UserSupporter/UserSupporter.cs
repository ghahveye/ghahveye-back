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
        [ForeignKey("User")]
        public string UserId { get; set; }
        [Required]
        [ForeignKey("Supporter")]
        public Guid SupporterId { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual List<Supporter> Supporter { get; set; }
    }
}
