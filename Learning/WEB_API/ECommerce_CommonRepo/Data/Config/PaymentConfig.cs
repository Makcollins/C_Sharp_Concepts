using System;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Data.Config;

public class PaymentConfig : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("Payments");
        builder.HasKey(payment => payment.PaymentID);

        builder.Property(payment => payment.ProductID).IsRequired();
        builder.Property(payment => payment.UserID).IsRequired();
        builder.Property(payment => payment.Quantity).IsRequired();
        builder.Property(payment => payment.Amount).IsRequired();
        builder.Property(payment => payment.PaymentDate).IsRequired();

        builder.HasMany(r => r.Products)
        .WithOne(r => r.Payment)
        .HasForeignKey(product => product.ProductID)
        .HasConstraintName("FK_Payment_Product");

        builder.HasOne(r => r.User)
        .WithOne(r => r.Payment)
        .HasForeignKey<User>(user => user.UserID)
        .HasConstraintName("FK_User_Payment");
    }
}
