using System;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using TicketManager.Data;
using TicketManager.DTOs;
using TicketManager.Models;

namespace TicketManager.Repository;

public class TicketRepository : ITicketRepository
{
    private readonly TicketContext _context;
    public TicketRepository(TicketContext context) => _context = context;

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

    public async Task<List<TicketsResponseDTO>> GetAllAsync()
    {
        var tickets = await _context.Tickets.ToListAsync();

        var ticketsDTO = tickets.Select(ticket => new TicketsResponseDTO()
        {
            ticket_id = ticket.ticket_id,
            title = ticket.title,
            description = ticket.description,
            assignee = ticket.assignee,
            status = ticket.status,
            promise_date = ticket.promise_date,
            attachments = ticket.attachments
        });
        return ticketsDTO.ToList();
    }

    public async Task<List<TicketsResponseDTO>> GetFiltered(Expression<Func<Ticket, bool>> filter)
    {
        var tickets = await _context.Tickets.Where(filter).ToListAsync();

        var ticketsDTO = tickets.Select(ticket => new TicketsResponseDTO()
        {
            ticket_id = ticket.ticket_id,
            title = ticket.title,
            description = ticket.description,
            assignee = ticket.assignee,
            status = ticket.status,
            promise_date = ticket.promise_date,
            attachments = ticket.attachments
        });

        return ticketsDTO.ToList();
    }

    public async Task<Ticket> GetByIDAsync(int id) => await _context.Tickets.FindAsync(id);

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

    public async Task UploadFileToTicket(int id, string fileName)
    {
        var ticket = await GetByIDAsync(id);

        ticket.attachments.Add(fileName);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveFileFromTicket(Ticket ticket, int id, string fileName)
    {
        if(ticket.attachments.FirstOrDefault() != null)
            ticket.attachments.Remove(fileName);

        if (File.Exists($"Uploads/{fileName}"))
            File.Delete($"Uploads/{fileName}");

        await _context.SaveChangesAsync();
    }
}
