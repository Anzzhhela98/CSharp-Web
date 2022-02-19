using Git.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Git.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Commit> Commits { get; set; }
        public DbSet<Repository> Repositories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=Git;Integrated Security=true;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
             .Entity<Repository>()
             .HasOne(r => r.Owner)
             .WithMany(o => o.Repositories)
             .HasForeignKey(r => r.OwnerId)
             .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Commit>(x =>
            {
                x.HasOne(x => x.Creator)
                .WithMany(x => x.Commits)
                .HasForeignKey(x => x.CreatorId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder
               .Entity<Commit>()
               .HasOne(c => c.Repository)
               .WithMany(r => r.Commits)
               .HasForeignKey(c => c.RepositoryId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
