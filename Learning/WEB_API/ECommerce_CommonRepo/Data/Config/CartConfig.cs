using System;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Config;

public class CartConfig : IEntityTypeConfiguration<Cart>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Cart> builder)
    {
        builder.ToTable("Carts");
        builder.HasKey(x => x.CartID);

        builder.Property(p => p.ProductID).IsRequired();
        builder.Property(p => p.Count).IsRequired();
        builder.Property(p => p.UserID).IsRequired();

        // builder.HasMany(rel => rel.Products)
        // .WithOne(rel => rel.Cart)
        // .HasForeignKey(p => p.ProductID)
        // .HasConstraintName("FK_Cart_Product");

        builder.HasOne(rel => rel.User)
        .WithOne(rel => rel.Cart)
        .HasForeignKey<User>(u => u.UserID)
        .HasConstraintName("FK_Cart_User");
    }
}
