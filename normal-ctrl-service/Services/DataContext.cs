using System;
using Microsoft.EntityFrameworkCore;
using RegularService.Models;

namespace RegularService.Services
{
    public class DataContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<OrderDetail>().ToTable("OrderDetail");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Shipper>().ToTable("Shipper");
            modelBuilder.Entity<Supplier>().ToTable("Supplier");

            var emp1 = new Employee() 
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "John",
                LastName = "Doe",
                Title = "The Boss",
                BirthDate = DateTime.Now.AddYears(-30),
                Address = "123 2nd Street",
                City = "New York",
                Region = "NY",
                PostalCode = "12345-1234",
                Country = "USA",
                Phone = "(405) 555-1212",
                HireDate = DateTime.Now.AddYears(-2)
            };

            modelBuilder.Entity<Employee>().HasData(emp1);
        }
    }
}