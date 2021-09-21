using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Ticket
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("User")]
        [Required]
        public string UserId { get; set; }
        [Required]
        public Guid UserPickerId { get; set; }
        [Required,MinLength(3),MaxLength(150)]
        public string Title { get; set; }
        public bool IsClosed { get; set; }
        public DateTime CreateDate { get; set; }
        public ApplicationUser User { get; set; }
        public Department Department { get; set; }
    }
}
