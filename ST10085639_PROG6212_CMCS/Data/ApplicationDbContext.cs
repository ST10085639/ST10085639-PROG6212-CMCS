using Microsoft.EntityFrameworkCore;
using ST10085639_PROG6212_CMCS.Models;

namespace ST10085639_PROG6212_CMCS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Claim> Claims { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure decimal precision for HourlyRate and TotalAmount
            modelBuilder.Entity<Claim>()
                .Property(c => c.HourlyRate)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Claim>()
                .Ignore(c => c.TotalAmount);
        }
    }
}