using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Chat
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid TicketId { get; set; }
        public Guid? ParentId { get; set; }
        [Required,MaxLength(500),MinLength(10)]
        public string Message { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [ForeignKey("ParentId")]
        public ICollection<Chat> Children { get; set; } = new List<Chat>();

    }
}
