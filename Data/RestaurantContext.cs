using Microsoft.EntityFrameworkCore;
using Restaurant.Models;

namespace Restaurant.Data
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Models.Restaurant> Restaurants{ get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Menu> Menus { get; set; }

        public DbSet<Table> Tables { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuring one-to-many relationship between Customer and Order
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.FK_CustomerId)
                .OnDelete(DeleteBehavior.NoAction);

            // Configuring one-to-many relationship between Menu and Order
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Menu)
                .WithMany(m => m.Orders)
                .HasForeignKey(o => o.FK_MenuId)
                .OnDelete(DeleteBehavior.NoAction);

            // Configuring one-to-many relationship between Table and Order
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Table)
                .WithMany(t => t.Orders)
                .HasForeignKey(o => o.FK_TableId)
                .OnDelete(DeleteBehavior.NoAction);

            // Configuring one-to-many relationship between Restaurant and Customer
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Restaurant)
                .WithMany(r => r.Customers)
                .HasForeignKey(c => c.FK_RestaurantId)
                .OnDelete(DeleteBehavior.NoAction);

            // Configuring one-to-many relationship between Restaurant and Menu
            modelBuilder.Entity<Menu>()
                .HasOne(m => m.Restaurant)
                .WithMany(r => r.Menus)
                .HasForeignKey(m => m.FK_RestaurantId)
                .OnDelete(DeleteBehavior.NoAction);

            // Configuring one-to-many relationship between Restaurant and Table
            modelBuilder.Entity<Table>()
                .HasOne(t => t.Restaurant)
                .WithMany(r => r.Tables)
                .HasForeignKey(t => t.FK_RestaurantId)
                .OnDelete(DeleteBehavior.NoAction);

            // Configuring one-to-many relationship between Customer and Reservation
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Customer)
                .WithMany(c => c.Reservations)
                .HasForeignKey(r => r.FK_CustomerId)
                .OnDelete(DeleteBehavior.NoAction);

            // Configuring one-to-many relationship between Table and Reservation
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Table)
                .WithMany(t => t.Reservations)
                .HasForeignKey(r => r.FK_TableId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
