using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BankAccount
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid BankAccountId { get; set; }
        [Required]
        public int CartNumber { get; set; }
        [Required]
        public int ShebaNumber { get; set; }
        [Required, MaxLength(50)]
        public string OwnerName { get; set; }
        [ForeignKey("BankAccountId")]
        public virtual BankAccounts BankAccounts { get; set; }
    }
}
