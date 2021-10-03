using Domain.Entities;
using Domain.Entities.SocialMedia;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infanstructor.Persistence
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options)
        { }
        public DbSet<BankAccounts> BankAccounts { get; set; }
        public DbSet<BankAccount> bankAccountAccounts { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DisLike> DisLikes { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Donate> Donates { get; set; }
        public DbSet<IdPayAccount> IdPayAccounts { get; set; }
        public DbSet<PaymentHistory> PaymentHistories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Supporter> Supporters { get; set; }
        public DbSet<Target> Targets { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<UserSupporter> UserSupporters { get; set; }
        public DbSet<Wallet> Wallets { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
