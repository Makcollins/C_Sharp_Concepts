using System;
using TicketManagementService.Models;

namespace TicketManagementService.Repository;

public interface ITicketRepository
{
    Task<List<Ticket>> GetAllAsync();
    Task<Ticket> GetByIDAsync(int id);
    Task UpdateAsync(Ticket ticket);
    Task<int> CreateAsync(Ticket ticket);
    Task DeleteAsync(int id);
    Task<List<string>> GetFilesNames(int id);
}
