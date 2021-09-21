using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Entities.Profile
{
    public class Profile
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required,MaxLength(20)]
        public string FirstName { get; set; }
        [Required, MaxLength(20)]
        public string LastName { get; set; }
        [Required, MaxLength(300)]
        public string ConvincingReasons { get; set; }
        [Required, MaxLength(260)]
        public string AboutMe { get; set; }
        [Required,MaxLength(50)]
        public string Position { get; set; }
        [Required, MaxLength(50)]
        public string Province { get; set; }
        [Required, MaxLength(30)]
        public string City { get; set; }
        [Required, MaxLength(300)]
        public string Address { get; set; }
        [Required]
        public string Avatar { get; set; }
        [Required]
        public string InvationLink { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}
