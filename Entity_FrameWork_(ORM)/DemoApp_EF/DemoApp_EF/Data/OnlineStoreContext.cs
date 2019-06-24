using DemoApp_EF.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp_EF.Data
{
    public class OnlineStoreContext : DbContext
    {
        private string _connectionString;

        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Order> Orders { get; set; }

        public OnlineStoreContext()
        {
            _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=OnlineStoreEF;Integrated Security=true";
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Customer>()
                .HasAlternateKey(c => c.Name)
                .HasName("UQ_Customers_Name");

            modelBuilder
                .Entity<OrderItem>()
                .HasKey("OrderId", "ProductId")
                .HasName("PK_OrderItems");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
