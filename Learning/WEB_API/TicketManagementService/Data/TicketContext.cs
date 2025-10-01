using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TicketManagementService.Models;

namespace TicketManagementService.Data;

public class TicketContext : DbContext
{
    public TicketContext(DbContextOptions<TicketContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ticket>().HasKey(t=>t.ticket_id);

        modelBuilder.Entity<Ticket>(ticketEntity =>
        {
            ticketEntity.Property(t => t.title).HasMaxLength(50);
            ticketEntity.Property(t => t.description).IsRequired(false).HasMaxLength(500);
            ticketEntity.Property(t => t.status).HasConversion<string>();
        });
    }
    
    public DbSet<Ticket> Tickets { get; set; }
}
