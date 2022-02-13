namespace SharedTrip.Data
{
    using Microsoft.EntityFrameworkCore;
    using SharedTrip.Models;

    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<UserTrip> UserTrips { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTrip>(entity =>
            {
                entity.HasKey(sc => new { sc.TripId, sc.UserId });
                entity
                .HasOne(sc => sc.User)
                .WithMany(s => s.UserTrips)
                .HasForeignKey(sc => sc.UserId);
                entity
                .HasOne(sc => sc.Trip)
                .WithMany(c => c.UserTrips)
                .HasForeignKey(sc => sc.TripId);
            });
        }
    }
}
