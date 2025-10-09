using System;
using Microsoft.EntityFrameworkCore;
using TicketManager.Models;

namespace TicketManager.Data;

public class TicketContext : DbContext
{
    public TicketContext(){}
    public TicketContext(DbContextOptions<TicketContext> options) : base(options)
    { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // base.OnConfiguring();
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=Mak.2017;Database=ticket_manager_db");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ticket>().HasKey(t => t.ticket_id);

        modelBuilder.Entity<Ticket>(ticketEntity =>
        {
            ticketEntity.Property(t => t.title).HasMaxLength(50);
            ticketEntity.Property(t => t.description).IsRequired(false).HasMaxLength(500);
            ticketEntity.Property(t => t.status).HasConversion<string>();
        });
    }
    public DbSet<Ticket> Tickets { get; set; }
}
