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

        public DbSet<Models.Restaurant> Restaurants { get; set; }

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

            base.OnModelCreating(modelBuilder);

            // Seed data for Restaurants
            modelBuilder.Entity<Models.Restaurant>().HasData
            (
                new Models.Restaurant { Id = 1, RestaurantName = "Italian Bistro", TypeOfRestaurant = "Italian" },
                new Models.Restaurant { Id = 2, RestaurantName = "Sushi Palace", TypeOfRestaurant = "Japanese" },
                new Models.Restaurant { Id = 3, RestaurantName = "Steak House", TypeOfRestaurant = "American" }
            );

            // Seed data for Tables
            modelBuilder.Entity<Table>().HasData
            (
                new Table { Id = 1, TableNumber = 1, AmountOfSeats = 4, FK_RestaurantId = 1 },
                new Table { Id = 2, TableNumber = 2, AmountOfSeats = 2, FK_RestaurantId = 1 },
                new Table { Id = 3, TableNumber = 3, AmountOfSeats = 6, FK_RestaurantId = 2 },
                new Table { Id = 4, TableNumber = 4, AmountOfSeats = 4, FK_RestaurantId = 3 },
                new Table { Id = 5, TableNumber = 5, AmountOfSeats = 8, FK_RestaurantId = 3 }
            );

            // Seed data for Customers
            modelBuilder.Entity<Customer>().HasData
            (
                new Customer { Id = 1, Name = "John Doe", Phone = 123456790, Email = "john@example.com", FK_RestaurantId=null},
                new Customer { Id = 2, Name = "Jane Smith", Phone = 98743210, Email = "jane@example.com", FK_RestaurantId=null},
                new Customer { Id = 3, Name = "Alice Johnson", Phone = 65654654, Email = "alice@example.com", FK_RestaurantId=null}
            );

            // Seed data for Menus
            modelBuilder.Entity<Menu>().HasData
            (
                new Menu { Id = 1, NameOfDish = "Spaghetti Carbonara", Drink = "Wine", Price = 12.99, IsAvailable = true, FK_RestaurantId = 1 },
                new Menu { Id = 2, NameOfDish = "Sushi Combo", Drink = "Sake", Price = 15.99, IsAvailable = true, FK_RestaurantId = 2 },
                new Menu { Id = 3, NameOfDish = "Grilled Steak", Drink = "Beer", Price = 20.99, IsAvailable = true, FK_RestaurantId = 3 }
            );

            // Seed data for Reservations
            modelBuilder.Entity<Reservation>().HasData
            (
                new Reservation
                {
                    Id = 1,
                    FK_CustomerId = 1,
                    FK_TableId = 1,
                    FK_RestaurantId = 1,
                    NumberOfGuests = 2,
                    BookingStart = DateTime.Now.AddHours(1),
                    BookingEnd = DateTime.Now.AddHours(3)
                },
                new Reservation
                {
                    Id = 2,
                    FK_CustomerId = 2,
                    FK_TableId = 3,
                    FK_RestaurantId=2,
                    NumberOfGuests = 3,
                    BookingStart = DateTime.Now.AddDays(1),
                    BookingEnd = DateTime.Now.AddDays(1).AddHours(2)
                }
                );
        }
    }
}