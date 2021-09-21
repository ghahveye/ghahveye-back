using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class IdPayAccount
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [ForeignKey("BankAccounts")]
        public Guid BankAccountId { get; set; }
        [Required, MaxLength(256)]
        public string IdPayWallet { get; set; }
        [Required, MaxLength(50),MinLength(5)]
        public string OwnerName { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }

        public virtual BankAccounts BankAccounts { get; set; }
    }
}
