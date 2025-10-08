using System;
using Microsoft.EntityFrameworkCore;

namespace LearnSQLite;

public class DataContext : DbContext
{
    public DataContext()
    {
        this.Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlite(@"Data Source = person.db");
    }
    public DbSet<Person> people { get; set; }
}
