using Microsoft.AspNetCore.Mvc;
using TicketSystem.Services;

namespace TicketSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly TicketService _ticketService;

        public TicketController(TicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket(string mobileNumber, string ticketHtml)
        {
            try
            {
                await _ticketService.CreateTicket(mobileNumber, ticketHtml);
                return Ok("Ticket created successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTickets()
        {
            var tickets = await _ticketService.GetAllTickets();
            return Ok(tickets);
        }

        [HttpGet("{mobileNumber}")]
        public async Task<IActionResult> GetUserTicket(string mobileNumber)
        {
            try
            {
                var ticket = await _ticketService.GetUserTicket(mobileNumber);
                return Ok(ticket);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
