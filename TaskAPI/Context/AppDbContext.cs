using Microsoft.EntityFrameworkCore;
using TaskAPI.Models;

namespace TaskAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure cascading delete for User-Task relationship
            modelBuilder.Entity<User>()
                .HasMany(u => u.Tasks)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
   
 }

