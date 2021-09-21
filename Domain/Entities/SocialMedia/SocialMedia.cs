using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities;

namespace Domain.Entities.SocialMedia
{
    public class SocialMedia
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required,MaxLength(50)]
        public string Title { get; set; }
        [Required,MaxLength(256)]
        public string Link { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}
