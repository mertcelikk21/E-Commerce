using eTicaret.Core.DbModels;
using eTicaret.Core.Interfaces;
using eTicaret.Infrastructure.DataContext;
using eTicaret.Infrastructure.Implements;
using System;
using System.Collections;
using System.Threading.Tasks;

namespace eTicaret.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreContext _context;
        private Hashtable _repositories;
        public UnitOfWork(StoreContext context)
        {
            _context = context;
        }
        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            if (_repositories == null) _repositories = new Hashtable();
            var type = typeof(TEntity).Name;
            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                var repositorynstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                _repositories.Add(type, repositorynstance);
            }
            return (IGenericRepository<TEntity>)_repositories[type];
        }
    }
}
