namespace Application.Interfaces
{
    public interface IRepository<T>
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T generic);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, T generic);
    }
}
