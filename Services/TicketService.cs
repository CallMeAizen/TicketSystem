using TicketSystem.Models;
using TicketSystem.Repositories;

namespace TicketSystem.Services
{
    public class TicketService
    {
        private readonly IRepository<Ticket> _ticketRepository;
        private readonly IRepository<User> _userRepository;

        public TicketService(IRepository<Ticket> ticketRepository, IRepository<User> userRepository)
        {
            _ticketRepository = ticketRepository;
            _userRepository = userRepository;
        }

        public async Task CreateTicket(string mobileNumber, string ticketHtml)
        {
            var user = (await _userRepository.GetAll()).FirstOrDefault(u => u.MobileNumber == mobileNumber);
            if (user == null) throw new Exception("User not found");
            if (user.Ticket != null) throw new Exception("User already has a ticket");

            var ticketImage = ConvertHtmlToImage(ticketHtml); // Implement this method to convert HTML to image

            var ticket = new Ticket
            {
                TicketNumber = Guid.NewGuid().ToString(),
                TicketImage = ticketImage,
                UserId = user.Id
            };

            await _ticketRepository.Add(ticket);
        }

        public async Task<IEnumerable<Ticket>> GetAllTickets()
        {
            return await _ticketRepository.GetAll();
        }

        public async Task<Ticket> GetUserTicket(string mobileNumber)
        {
            var user = (await _userRepository.GetAll()).FirstOrDefault(u => u.MobileNumber == mobileNumber);
            if (user == null || user.Ticket == null) throw new Exception("Ticket not found");

            return user.Ticket;
        }

        private string ConvertHtmlToImage(string html)
        {
            // Implement HTML to image conversion logic
            // This might require using an external library or API
            return "path/to/generated/image.jpg";
        }
    }
}
