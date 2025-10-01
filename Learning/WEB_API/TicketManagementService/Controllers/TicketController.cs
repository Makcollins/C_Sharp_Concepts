using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using TicketManagementService.Data;
using TicketManagementService.DTOs;
using TicketManagementService.Models;
using TicketManagementService.Repository;

namespace TicketManagementService
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IAttachmentsRepository _attachments;

        public TicketController(ITicketRepository ticketRepository, IAttachmentsRepository attachments)
        {
            _ticketRepository = ticketRepository;
            _attachments = attachments;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket([FromForm] TicketsDTO model, List<IFormFile> files)
        {
            var ticket = new Ticket
            {
                title = model.title,
                description = model.description,
                assignee = model.assignee,
                status = model.status,
                promise_date = model.promise_date,
                attachments = await _attachments.Upload(files)
            };

            model.ticket_id = await _ticketRepository.CreateAsync(ticket);

            return Ok("Successful");
        }

        [HttpGet]
        public async Task<ActionResult<TicketsResponseDTO>> GetAllTickets()
        {
            var tickets = await _ticketRepository.GetAllAsync();

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

            return Ok(ticketsDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TicketsResponseDTO>> GetTicketByID(int id)
        {
            var ticket = await _ticketRepository.GetByIDAsync(id);

            var ticketsDTO = new TicketsResponseDTO
            {
                ticket_id = ticket.ticket_id,
                title = ticket.title,
                description = ticket.description,
                assignee = ticket.assignee,
                status = ticket.status,
                promise_date = ticket.promise_date,
                attachments = ticket.attachments
            };

            return Ok(ticketsDTO);
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateTicket([FromForm] TicketsDTO model, List<IFormFile> files)
        {
            try
            {
                var ticketToUpdate = await _ticketRepository.GetByIDAsync(model.ticket_id);
    
                if (ticketToUpdate == null)
                {
                    return NotFound("Ticket Not Found");
                }
                ticketToUpdate.title = model.title;
                ticketToUpdate.description = model.description;
                ticketToUpdate.assignee = model.assignee;
                ticketToUpdate.status = model.status;
                ticketToUpdate.promise_date = model.promise_date;
                ticketToUpdate.attachments = await _attachments.Upload(files);
    
                await _ticketRepository.UpdateAsync(ticketToUpdate);
    
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, new { err = "Server Error" });
            }

        }

        [HttpDelete]
        public async Task<ActionResult> DeleteTicket(int id)
        {
            try
            {
                await _ticketRepository.DeleteAsync(id);
                return NoContent();
            }
            catch (ArgumentNullException)
            {
                return NotFound("Ticket not Found");
            }
            catch (Exception)
            {
                return StatusCode(500, new { error = "Server Error" });
            }
        }

    }
}
