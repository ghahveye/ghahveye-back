using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PaymentHistory
    {
        public Guid Id { get; set; }
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public bool IsSuccess { get; set; }
        public decimal Amount { get; set; }
        [Required,MaxLength(265),MinLength(5)]
        public string TransactionSection { get; set; }


        public ApplicationUser User { get; set; }
        public virtual Wallet Walet { get; set; }
        public virtual Product Product { get; set; }
    }
}
