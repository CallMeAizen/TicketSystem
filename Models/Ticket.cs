namespace TicketSystem.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string TicketNumber { get; set; }
        public string TicketImage { get; set; } // Path to the image
        public int UserId { get; set; }
        public User User { get; set; }
    }
}