using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentsAPI.Models;

namespace StudentsAPI.Data.Config;

public class StudentConfig : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Students");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).UseIdentityColumn();
        builder.Property(x => x.StudentName).IsRequired().HasMaxLength(250);
        builder.Property(x => x.Address).IsRequired(false).HasMaxLength(500);
        builder.Property(x => x.Email).IsRequired().HasMaxLength(250);
    }
}
