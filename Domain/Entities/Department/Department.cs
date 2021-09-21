using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Department
    {
        [Key]
        public Guid Id { get; set; }
        [Required, MaxLength(100)]
        public string Title
        {
            get; set;
        }
        [ForeignKey("Ticket")]
        public Guid TicketId { get; set; }
        public Ticket Ticket { get; set; }
    }
}
