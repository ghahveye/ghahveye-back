using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        [ForeignKey("User")]
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public bool IsAvailable { get; set; }
        public int Star { get; set; }
        [Required]
        public int InStock { get; set; }
        [Required, MinLength(10), MaxLength(200)]
        public string Title { get; set; }
        [Required,MinLength(50),MaxLength(700)]
        public string Description { get; set; }
        public ApplicationUser User { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<DisLike> DisLikes { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
