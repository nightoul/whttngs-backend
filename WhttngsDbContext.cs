using Microsoft.EntityFrameworkCore;
using whttngs_backend.Models;

namespace whttngs_backend
{
    public class WhttngsDbContext : DbContext
    {
        public WhttngsDbContext(DbContextOptions<WhttngsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Visit> Visits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define relationships and any constraints here if needed
            modelBuilder.Entity<Post>()
                        .HasMany(p => p.Visits)
                        .WithOne(v => v.Post)
                        .HasForeignKey(v => v.PostId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
