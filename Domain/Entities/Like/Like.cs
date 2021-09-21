using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Like
    {
        public Guid Id { get; set; }
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Product Product { get; set; }
    }
}
