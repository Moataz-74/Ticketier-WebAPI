using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ticketier_WebAPI.Core.Context;
using Ticketier_WebAPI.Core.DTO;
using Ticketier_WebAPI.Core.Models;

namespace Ticketier_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public TicketsController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateTicket(CreateTicketDTO ticketDTO)
        {
            var newTicket = new Ticket();
            mapper.Map(ticketDTO, newTicket);
            await context.Tickets.AddAsync(newTicket);
            await context.SaveChangesAsync();
            return Ok(newTicket);
        }
        [HttpGet]
        public async Task<ActionResult<List<CreateTicketDTO>>> GetAllTickets()
        {
            var Tickets = await context.Tickets.ToListAsync();

            var convertedTickets = mapper.Map<List<CreateTicketDTO>>(Tickets);
            return Ok(convertedTickets);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<CreateTicketDTO>> GetTicketById(long id)
        {
            var ticket = await context.Tickets.SingleOrDefaultAsync(t => t.Id == id);
            if(ticket == null)
            {
                return NotFound("Ticket not found");
            }
            var convertedTicket = mapper.Map<CreateTicketDTO>(ticket);
            return Ok(convertedTicket);
        }
        [HttpPut("edit/{id}")]
        public async Task<ActionResult<Ticket>> UpdateTicketById(long id,UpdateTicketDTO updateTicketDTO)
        {
            var ticket = context.Tickets.SingleOrDefault(t => t.Id == id);
            if(ticket == null)
            {
                return NotFound("Tikcet not found");
            }
            mapper.Map(updateTicketDTO , ticket);
            ticket.UpdatedAt = DateTime.Now;
           
          await  context.SaveChangesAsync();
            return Ok(ticket);
        }
        [HttpDelete("Delte/{id}")]
        public async Task <IActionResult> DeleteTicketById(long id)
        {
            var ticket = await context.Tickets.SingleOrDefaultAsync(t => t.Id == id);
            if( ticket == null )
            {
                return NotFound();
            }
            context.Tickets.Remove(ticket);
            await context.SaveChangesAsync();
            return Ok("Delted");
        }
    }
}
