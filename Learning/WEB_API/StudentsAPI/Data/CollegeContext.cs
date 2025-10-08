using System;
using Microsoft.EntityFrameworkCore;
using StudentsAPI.Models;

namespace StudentsAPI.Data;

public class CollegeContext : DbContext
{//ctor
    public CollegeContext(DbContextOptions<CollegeContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Student>().HasData(new List<Student>(){
            new Student { Id = 1, StudentName = "Emmanuel", Email = "emmanuel@gmail.com", Address = "Kisumu", DOB=new DateTime(2000,06,12).ToUniversalTime()},
            new Student { Id = 2, StudentName = "Steve", Email = "steve@gmail.com", Address = "Kisumu", DOB = new DateTime(2002,5,22).ToUniversalTime()}
        });
    }
    public DbSet<Student> Students { get; set; }
    public DbSet<Department> Departments { get; set; }
}
