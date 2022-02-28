using Microsoft.EntityFrameworkCore;
using Mock_twitter.Entities;

namespace Mock_twitter.Data_Access
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Friendship> Friendships { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Friendship>().HasKey(f => new { f.TargetUserId, f.FriendUserId });

            modelBuilder.Entity<Friendship>()
                .HasOne(f => f.TargetUser)
                .WithMany(p => p.MainFriendships)
                .HasForeignKey(f => f.TargetUserId)
                .OnDelete(DeleteBehavior.Restrict);//bu onun dost olduqlari, sorghu TargetUserId == User.Id

            modelBuilder.Entity<Friendship>()
                .HasOne(f => f.FriendUser)
                .WithMany(p => p.Friendships)
                .HasForeignKey(f => f.FriendUserId);//bu ona dost olanlar, sorghu FriendUserId == User.Id

            base.OnModelCreating(modelBuilder);
        }
    }

}