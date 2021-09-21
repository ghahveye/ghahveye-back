using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities;

namespace Domain.Entities
{
    public class Donate
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
        [Required]
        public Guid DonatedUserId { get; set; }
        [MaxLength(300),MinLength(5)]
        public string Message { get; set; }
        public bool IsHidden { get; set; }
        [Required,MinLength(2000)]
        public int Price { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Target Target { get; set; }

    }
}
