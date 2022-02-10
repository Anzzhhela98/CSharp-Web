namespace SMS.Data
{
    using Microsoft.EntityFrameworkCore;
    using SMS.Models;
    using static DatabaseConfiguration;

    // ReSharper disable once InconsistentNaming
    public class SMSDbContext : DbContext
    {
        public SMSDbContext()
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cart>()
                .HasOne<User>(u => u.User)
                .WithOne(c => c.Cart)
                .HasForeignKey<User>(fk => fk.CartId);
        }
    }
}