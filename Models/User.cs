using System.Net.Sockets;

namespace TicketSystem.Models
{
    public class User
    {
        public int Id { get; set; }
        public string MobileNumber { get; set; }
        public Ticket Ticket { get; set; }
    }
}