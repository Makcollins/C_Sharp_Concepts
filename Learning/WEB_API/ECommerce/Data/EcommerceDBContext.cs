using System;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data;

public class EcommerceDBContext : DbContext
{
    public EcommerceDBContext(DbContextOptions<EcommerceDBContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().HasData(
            new User { UserID = 1000, FirstName = "Collins", LastName = "Makui", age = 25, Gender = Gender.Male, Phone = "0745083702", Address = "Kisumu", Password = "1234mak" },
            new User { UserID = 1001, FirstName = "Asenath", LastName = "Kwamboka", age = 21, Gender = Gender.Female, Phone = "0716587454", Address = "Nakuru", Password = "ase12345" }
        );

        modelBuilder.Entity<Products>().HasData(
            new Products { ProductID = 1, CategoryID = 1, Count = 7, Price = 12500, ProductName = "Redmi 14c", Description = "5000w battery, camera 50MP" },
            new Products { ProductID = 2, CategoryID = 1, Count = 10, Price = 14000, ProductName = "Tecno spark 40", Description = "5000w battery, camera 50MP" }
        );

        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryID = 1, CategoryName = "Phones", Description = "Smart phones, tablets, iphone" },
            new Category { CategoryID = 2, CategoryName = "Laptops", Description = "Lenovo, Hp, Mac, Dell" }
        );

        modelBuilder.Entity<Cart>().HasData(
            new Cart { CartID = 1, Count = 2, ProductID = 1, UserID = 1000 },
            new Cart { CartID = 2, Count = 1, ProductID = 2, UserID = 1001 }
        );

        modelBuilder.Entity<Order>().HasData(
            new Order { OrderID = 1, CartID = 1, Count = 2, UserID = 1000 },
            new Order { OrderID = 2, CartID = 2, Count = 1, UserID = 1001 }
        );
        modelBuilder.Entity<Payment>().HasData(
            new Payment {PaymentID = 1, PaymentDate = "22/08/2025", Amount = 25000, ProductID = 1, Quantity = 2, UserID = 1000},
            new Payment {PaymentID = 2, PaymentDate = "23/08/2025", Amount = 14000, ProductID = 2, Quantity = 1, UserID = 1001}
        );
    }

    public DbSet<Cart> Carts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Products> Products { get; set; }
    public DbSet<User> Users { get; set; }

}
