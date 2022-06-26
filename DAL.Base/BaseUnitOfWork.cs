using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base;

namespace DAL.Base
{
    public abstract class BaseUnitOfWork : IBaseUnitOfWork
    {
        private readonly Dictionary<Type, object> _repoCache = new();
        public abstract Task<int> SaveChangesAsync();

        public TRepository GetRepository<TRepository>(Func<TRepository> repoCreationMethod)
            where TRepository : class
        {
            // if was in dict
            if (_repoCache.TryGetValue(typeof(TRepository), out var repo)) return (TRepository) repo;

            // if not in dict
            // create new instance.
            //Save it to  cach
            var repoInstance = repoCreationMethod();
            _repoCache.Add(typeof(TRepository), repoInstance);
            return repoInstance;
        }
    }
}