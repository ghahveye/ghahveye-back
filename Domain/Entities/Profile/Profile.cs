using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Entities
{
    public class Profile
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [MaxLength(20)]
        public string FirstName { get; set; }
        [MaxLength(20)]
        public string LastName { get; set; }
        [MaxLength(300)]
        public string ConvincingReasons { get; set; }
        [MaxLength(260)]
        public string AboutMe { get; set; }
        [MaxLength(50)]
        public string Position { get; set; }
        [MaxLength(50)]
        public string Province { get; set; }
        [MaxLength(30)]
        public string City { get; set; }
        [MaxLength(300)]
        public string Address { get; set; }
        public string Avatar { get; set; }
        public string InvationLink { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}
