using System;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Data.Config;

public class ProductsConfig :IEntityTypeConfiguration<Products>
{
    public void Configure(EntityTypeBuilder<Products> builder)
    {
        builder.ToTable("Products");
        builder.HasKey(x => x.ProductID);
        // builder.Property(p => p.ProductID).UseIdentityColumn();

        builder.Property(p => p.CategoryID).IsRequired();
        builder.Property(p => p.Count).IsRequired();
        builder.Property(p => p.Price).IsRequired();
        builder.Property(p => p.ProductName).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Description).IsRequired();

        builder.HasData(
            new Products { ProductID = 1, CategoryID = 1, Count = 7, Price = 12500, ProductName = "Redmi 14c", Description = "5000w battery, camera 50MP" },
            new Products { ProductID = 2, CategoryID = 1, Count = 10, Price = 14000, ProductName = "Tecno spark 40", Description = "5000w battery, camera 50MP" }
        );
    }
}
