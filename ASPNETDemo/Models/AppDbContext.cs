using Microsoft.EntityFrameworkCore;

namespace ASPNETDemo.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Grade)
                .WithMany(a => a.Students)
                .IsRequired(false); // This makes the foreign key nullable

            // Other configurations...
            base.OnModelCreating(modelBuilder);
        }
    }
}
