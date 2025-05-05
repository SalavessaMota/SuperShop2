using Microsoft.EntityFrameworkCore;
using SuperShop2.Data.Entities;

namespace SuperShop2.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=SuperShop2;ConnectRetryCount=0");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(p => p.Price).HasPrecision(18, 2);

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "IPhone X",
                    Price = 750,
                    LastPurchase = new DateTime(2025, 2, 1),
                    LastSale = new DateTime(2025, 2, 2),
                    IsAvailable = true,
                    Stock = 100,
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 2,
                    Name = "Samsung S25",
                    Price = 1500,
                    LastPurchase = new DateTime(2025, 3, 1),
                    LastSale = new DateTime(2025, 3, 2),
                    IsAvailable = true,
                    Stock = 200,
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 3,
                    Name = "Logitech Mx 3s",
                    Price = 100,
                    LastPurchase = new DateTime(2025, 4, 1),
                    LastSale = new DateTime(2025, 4, 2),
                    IsAvailable = true,
                    Stock = 50,
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 4,
                    Name = "IPad Mini",
                    Price = 500,
                    LastPurchase = new DateTime(2025, 5, 1),
                    LastSale = new DateTime(2025, 5, 2),
                    IsAvailable = true,
                    Stock = 120,
                }
            );

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Product> Products { get; set; }

    }
}
