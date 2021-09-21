using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Wallet
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public decimal Amount { get; set; }

        public ICollection<PaymentHistory> PaymentHistory { get; set; }
        public ApplicationUser User { get; set; }
    }
}
