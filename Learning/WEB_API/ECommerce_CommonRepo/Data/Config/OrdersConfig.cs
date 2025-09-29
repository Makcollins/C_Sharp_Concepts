using System;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Config;

public class OrdersConfig : IEntityTypeConfiguration<Order>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");
        builder.HasKey(order => order.OrderID);

        builder.Property(order => order.UserID).IsRequired(false);
        builder.Property(order => order.CartID).IsRequired(false);
        builder.Property(order => order.Count).IsRequired();

        builder.HasOne(r => r.User)
        .WithMany(r => r.Orders)
        .HasForeignKey(user => user.UserID)
        .HasConstraintName("FK_Order_User");

        builder.HasOne(r => r.Cart)
        .WithMany(r => r.Orders)
        .HasForeignKey(cart => cart.CartID)
        .HasConstraintName("FK_Order_Cart");
    }
}
