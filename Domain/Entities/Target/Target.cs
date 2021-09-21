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
    public class Target
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [ForeignKey("User")]
        public Guid UserId  { get; set; }
        [Required,MaxLength(64),MinLength(3)]
        public string Title { get; set; }
        [Required, MaxLength(500), MinLength(30)]
        public string Description { get; set; }
        [Required , MaxLength(500), MinLength(30)]
        public string ConvincingReasons { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Donate> Donates { get; set; } 
    }
}
