using Herfitk.Core.Repository;

namespace Herfitk.Core
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;

        Task<int> CompleteAsync();

        IHerifyRepository herifyRepository { get; }
        IStaffRepository staffRepository { get; }
    }
}