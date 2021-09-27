using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsVerified { get; set; }
        public bool IsBanned { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual Profile.Profile Profile { get; set; }
        public virtual ICollection<SocialMedia.SocialMedia> SocialMedias { get; set; }
        public virtual ICollection<UserSupporter> UserSupporters { get; set; }
        public virtual ICollection<Target> Targets { get; set; }
        public virtual ICollection<Donate>  Donates{ get; set; }
        public virtual ICollection<PaymentHistory> PaymentHistories { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }


    }
}
