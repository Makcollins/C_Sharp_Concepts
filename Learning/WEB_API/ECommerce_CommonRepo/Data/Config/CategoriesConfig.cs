using System;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Data.Config;

public class CategoriesConfig : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");
        builder.HasKey(x => x.CategoryID);

        builder.Property(c => c.CategoryName).IsRequired().HasMaxLength(250);
        builder.Property(c => c.Description).HasMaxLength(500).IsRequired(false);
    }
}
