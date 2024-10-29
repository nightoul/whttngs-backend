using whttngs_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace whttngs_backend
{
    public class WhttngsDbContext : DbContext
    {
        public WhttngsDbContext(DbContextOptions<WhttngsDbContext> options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; } = null!;
        public DbSet<Video> Videos { get; set; } = null!;
        public DbSet<VideoView> VideoViews { get; set; } = null!;
        public DbSet<Visit> Visits { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Additional configurations if needed
            modelBuilder.Entity<Post>()
                .HasOne<Video>()
                .WithMany()
                .HasForeignKey(p => p.VideoId)
                .IsRequired(false); // Makes VideoId nullable
        }
    }
}
