using System;
using System.Linq.Expressions;
using TicketManagementService.DTOs;
using TicketManagementService.Models;

namespace TicketManagementService.Repository;

public interface ITicketRepository
{
    Task<List<TicketsResponseDTO>> GetAllAsync();
    Task<List<TicketsResponseDTO>> GetFiltered(Expression<Func<Ticket, bool>> filter);
    Task<Ticket> GetByIDAsync(int id);
    Task UpdateAsync(Ticket ticket);
    Task<int> CreateAsync(Ticket ticket);
    Task DeleteAsync(int id);
    Task<List<string>> GetFilesNames(int id);
}
