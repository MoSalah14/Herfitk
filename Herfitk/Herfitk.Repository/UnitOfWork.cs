using Herfitk.Core;
using Herfitk.Core.Models.Data;
using Herfitk.Core.Repository;
using System.Collections;

namespace Herfitk.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HerfitkContext _HerfitkContext;

        private Hashtable _repositories;

        public IHerifyRepository herifyRepository { get; private set; }

        public IStaffRepository staffRepository { get; private set; }

        public UnitOfWork(HerfitkContext herfutkContext)
        {
            _HerfitkContext = herfutkContext;
            _repositories = new Hashtable();
            herifyRepository = new HerifyRepository(_HerfitkContext);
            staffRepository = new StaffRepository(_HerfitkContext);
        }

        public async Task<int> CompleteAsync()
               => await _HerfitkContext.SaveChangesAsync();

        public async ValueTask DisposeAsync()
            => await _HerfitkContext.DisposeAsync();

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            var Key = typeof(TEntity).Name; // Check If Key(Object of repo is Created or not)
            if (!_repositories.ContainsKey(Key))
            {
                var repository = new GenericRepository<TEntity>(_HerfitkContext);
                _repositories.Add(Key, repository);
            }

            return _repositories[Key] as IGenericRepository<TEntity>;
        }
    }
}