namespace Herfitk.Core.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecification<T> specification);

        Task<T?> GetByIdAsync(int id);

        Task<T?> GetByIdWithSpecAsync(ISpecification<T> specification);

        Task<T> AddAsync(T name);

        public Task UpdateAsync(T name, int id);

        public Task DeleteAsync(int id);
    }
}