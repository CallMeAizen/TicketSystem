using TicketSystem.Models;
using TicketSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace TicketSystem.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.Include(u => u.Ticket).ToListAsync();
        }

        public async Task<User> Get(int id)
        {
            return await _context.Users.Include(u => u.Ticket).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task Add(User entity)
        {
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(User entity)
        {
            _context.Users.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}