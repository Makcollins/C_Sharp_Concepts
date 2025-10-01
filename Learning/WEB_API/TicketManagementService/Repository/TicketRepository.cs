using System;
using Microsoft.EntityFrameworkCore;
using TicketManagementService.Data;
using TicketManagementService.Models;

namespace TicketManagementService.Repository;

public class TicketRepository : ITicketRepository
{
    private readonly TicketContext _context;
    public TicketRepository(TicketContext context)
    {
        _context = context;
    }
    public async Task<int> CreateAsync(Ticket ticket)
    {
        _context.Tickets.Add(ticket);
        await _context.SaveChangesAsync();
        return ticket.ticket_id;
    }

    public async Task DeleteAsync(int id)
    {
        var TicketToDelete = await _context.Tickets.FindAsync(id);
        List<string> files = TicketToDelete!.attachments;

        _context.Tickets.Remove(TicketToDelete);
        await _context.SaveChangesAsync();

        foreach (var file in files)
        {
            if (File.Exists($"Uploads/{file}"))
                File.Delete($"Uploads/{file}");
        }
    }

    public async Task<List<Ticket>> GetAllAsync()
    {
        return await _context.Tickets.ToListAsync();
    }

    public async Task<Ticket> GetByIDAsync(int id)
    {
        return await _context.Tickets.FindAsync(id);
    }

    public async Task<List<string>> GetFilesNames(int id)
    {
        var ticket = await GetByIDAsync(id);
        return ticket.attachments;
    }

    public async Task UpdateAsync(Ticket ticket)
    {
        _context.Update(ticket);

        await _context.SaveChangesAsync();
    }
}
