using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Supporter
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [ForeignKey("UserSupporter")]
        public Guid SupporterId { get; set; }
        [Required]
        public bool IsHidden { get; set; }
        [Required,MaxLength(256)]
        public string Message { get; set; }
        [Required]
        public int Price { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual ICollection<UserSupporter> UserSupporter { get; set; }
    }
}
