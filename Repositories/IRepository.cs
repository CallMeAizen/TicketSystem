namespace TicketSystem.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(int id);
    }
}