// Microsoft Learn. 2024. DbContext in Entity Framework Core, 12 November 2024. [Online]. Available at: https://learn.microsoft.com/en-us/ef/core/dbcontext-configuration/ [Accessed 16 October 2025].
// Microsoft Learn. 2024. Configuring entity properties with the Fluent API in EF Core, 28 March 2024. [Online]. Available at:https://learn.microsoft.com/en-us/ef/core/modeling/ [Accessed 16 October 2025].
// TutorialsTeacher. 2024. ASP.NET Core EF Core Tutorial, 2024. [Online]. Available at:https://www.tutorialsteacher.com/core/aspnet-core-ef-core [Accessed 16 October 2025].

using Microsoft.EntityFrameworkCore;
using ST10085639_PROG6212_CMCS.Models;

namespace ST10085639_PROG6212_CMCS.Data
{
    // This handles the databse access for the CMCS system
    // It inherits frim the DbContext which is provided by the Entity Framework Core
    public class ApplicationDbContext : DbContext
    {
        // The constructor configures the database connection and options using DbContextOptions
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Each Dbset connects to a model/ entity which allows CRUD operations
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