using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TicketManager.DTOs;
using TicketManager.Models;
using TicketManager.Repository;

namespace TicketManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IAttachmentsRepository _attachments;

        public TicketsController(ITicketRepository ticketRepository, IAttachmentsRepository attachments)
        {
            _ticketRepository = ticketRepository;
            _attachments = attachments;
        }

        //Creates a new ticket and upload attachments
        [HttpPost]
        public async Task<IActionResult> CreateTicket([FromForm] TicketsDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (model.promise_date < DateTime.Now)
            {
                ModelState.AddModelError("PromiseDateError", "Promise date must be greater or equal to current date");
                return BadRequest(ModelState);
            }

            try
            {
                var ticket = new Ticket
                {
                    title = model.title,
                    description = model.description,
                    assignee = model.assignee,
                    status = model.status,
                    promise_date = model.promise_date.ToUniversalTime(),
                    attachments = await _attachments.Upload(model.attachments)
                };

                await _ticketRepository.CreateAsync(ticket);

                var ticketResponse = new TicketsResponseDTO
                {
                    ticket_id = ticket.ticket_id,
                    description = ticket.description,
                    assignee = ticket.assignee,
                    status = ticket.status,
                    promise_date = ticket.promise_date.ToLocalTime(),
                    attachments = ticket.attachments
                };

                return CreatedAtAction(nameof(GetTicketByID), new { id = ticketResponse }, ticketResponse);
            }
            catch (Exception)
            {
                return StatusCode(500, new { error = "Server Error" });
            }
        }

        //return all availlable tickets
        [HttpGet]
        public async Task<ActionResult<TicketsResponseDTO>> GetAllTickets()
        {
            try
            {
                var tickets = await _ticketRepository.GetAllAsync();

                return Ok(tickets.OrderBy(t => t.ticket_id));
            }
            catch (Exception)
            {
                return StatusCode(500, new { error = "Server Error" });
            }
        }

        //sort Tickets in a descending order based on ID's
        [HttpGet("tickets=descending")]
        public async Task<ActionResult<TicketsResponseDTO>> GetAllTicketsDescending()
        {
            try
            {
                var tickets = await _ticketRepository.GetAllAsync();

                return Ok(tickets.OrderByDescending(t => t.ticket_id));
            }
            catch (Exception)
            {
                return StatusCode(500, new { error = "Server Error" });
            }
        }

        //return tickets for a specific assignee
        [HttpGet("{assignee:alpha}")]
        public async Task<ActionResult<TicketsResponseDTO>> GetFilteredByAsignee(string assignee)
        {
            var tickets = await _ticketRepository.GetFiltered(t => t.assignee == assignee);

            return Ok(tickets.OrderBy(t => t.ticket_id));
        }

        //returns tickets for a specific promise date
        //date format to test with on postman/swagger/thunderclient yyyy-MM-dd or yyyy,MM,dd or yyyy/MM/dd . e.g. 2025-10-02 or 2025,10,02 or 2025/10/02
        [HttpGet("date")]
        public async Task<ActionResult<TicketsResponseDTO>> GetFilteredByDate([FromQuery] DateTime specific_date)
        {
            var tickets = await _ticketRepository.GetFiltered(t => t.promise_date.ToLocalTime().Date == specific_date.Date);

            try
            {

                if (tickets == null)
                    return NotFound("Records not Found");

                return Ok(tickets.OrderBy(t => t.ticket_id));
            }
            catch (Exception)
            {
                return StatusCode(500, new { error = "Server Error" });
            }
        }

        //returns tickets for a specific range of date
        //date format to test with on postman/swagger/thunderclient yyyy-MM-dd or yyyy,MM,dd or yyyy/MM/dd . e.g. 2025-10-02 or 2025,10,02 or 2025/10/02
        [HttpGet("date_range")]
        public async Task<ActionResult<TicketsResponseDTO>> GetFilteredByDateRange([FromQuery] DateTime start_date, [FromQuery] DateTime end_date)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var tickets = await _ticketRepository.GetFiltered(t => (t.promise_date >= start_date.ToUniversalTime()) && (t.promise_date <= end_date.ToUniversalTime()));
                if (tickets == null)
                    return NotFound("Records not Found");

                return Ok(tickets.OrderBy(t => t.ticket_id));
            }
            catch (Exception)
            {
                return StatusCode(500, new { error = "Server Error" });
            }
        }

        //filters tickets based on status
        [HttpGet("status={ticket_status}")]
        public async Task<ActionResult<TicketsResponseDTO>> GetFilteredByStatus(TicketStatus ticket_status)
        {
            try
            {
                var tickets = await _ticketRepository.GetFiltered(t => t.status == ticket_status);
                if (tickets == null)
                    return NotFound("Records not Found");

                return Ok(tickets.OrderBy(t => t.ticket_id));
            }
            catch (Exception)
            {
                return StatusCode(500, new { error = "Server Error" });
            }
        }

        //Returns a specific ticket
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketsResponseDTO>> GetTicketByID(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var ticket = await _ticketRepository.GetByIDAsync(id);
                if (ticket == null)
                    return NotFound("Ticket Not Found!");

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
            catch (Exception)
            {
                return StatusCode(500, new { error = "Server Error" });
            }
        }

        //Update Ticket.
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateTicket(int id, [FromForm] TicketsDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var ticketToUpdate = await _ticketRepository.GetByIDAsync(id);
                var previousAttachments = ticketToUpdate.attachments;

                if (ticketToUpdate == null)
                {
                    return NotFound("Ticket Not Found");
                }
                ticketToUpdate.title = model.title;
                ticketToUpdate.description = model.description;
                ticketToUpdate.assignee = model.assignee;
                ticketToUpdate.status = model.status;
                ticketToUpdate.promise_date = model.promise_date;
                ticketToUpdate.attachments = await _attachments.Upload(model.attachments);

                await _ticketRepository.UpdateAsync(ticketToUpdate);
                foreach (var file in previousAttachments)
                {
                    await _attachments.DeleteFile(file);
                }

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, new { err = "Server Error" });
            }

        }

        //add an attachment
        [HttpPatch("{id}/attachments")]
        public async Task<IActionResult> AddAttachment(int id, [FromForm] List<IFormFile> files)
        {
            var ticket = await _ticketRepository.GetByIDAsync(id);
            ticket.attachments.AddRange(await _attachments.Upload(files));

            return Ok(ticket);
        }

        //Delete a ticket
        [HttpDelete]
        public async Task<ActionResult> DeleteTicket(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

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
