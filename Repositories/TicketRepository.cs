using TicketSystem.Models;
using TicketSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace TicketSystem.Repositories
{
    public class TicketRepository : IRepository<Ticket>
    {
        private readonly AppDbContext _context;

        public TicketRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ticket>> GetAll()
        {
            return await _context.Tickets.Include(t => t.User).OrderByDescending(t => t.TicketNumber).ToListAsync();
        }

        public async Task<Ticket> Get(int id)
        {
            return await _context.Tickets.Include(t => t.User).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task Add(Ticket entity)
        {
            await _context.Tickets.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Ticket entity)
        {
            _context.Tickets.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
        }
    }
}
