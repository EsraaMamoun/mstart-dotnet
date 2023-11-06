using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Account>()
                .Property(e => e.Server_DateTime)
                .HasDefaultValue(DateTime.Now);

            modelBuilder.Entity<Account>()
                .Property(e => e.DateTime_UTC)
                .HasDefaultValue(DateTime.UtcNow)
                .ValueGeneratedOnAdd(); 

            modelBuilder.Entity<Account>()
                .Property(e => e.Update_DateTime_UTC)
                .HasDefaultValue(DateTime.UtcNow) 
                .ValueGeneratedOnUpdate();

            modelBuilder.Entity<Account>()
                .Property(e => e.Status)
                .HasDefaultValue(Status.Active);

            modelBuilder.Entity<Account>()
                .HasIndex(a => a.Account_Number).IsUnique();

            modelBuilder.Entity<User>()
                .Property(e => e.Server_DateTime)
                .HasDefaultValue(DateTime.Now);

            modelBuilder.Entity<User>()
                .Property(e => e.DateTime_UTC)
                .HasDefaultValue(DateTime.UtcNow)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<User>()
                .Property(e => e.Update_DateTime_UTC)
                .HasDefaultValue(DateTime.UtcNow)
                .ValueGeneratedOnUpdate();

            modelBuilder.Entity<User>()
                .Property(e => e.Status)
                .HasDefaultValue(Status.Active);

            modelBuilder.Entity<User>()
               .HasIndex(u => u.Username).IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email).IsUnique();

        }
    }
}
