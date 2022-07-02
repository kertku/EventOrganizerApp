using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Domain.Base;

namespace Contracts.DAL.Base.Repositories
{
    public interface IBaseRepository<TEntity> : IBaseRepository<TEntity, Guid>
        where TEntity : class, IDomainEntityId<Guid>

    {
    }


    public interface IBaseRepository<TEntity, Tkey>
        where TEntity : class, IDomainEntityId<Tkey>
        where Tkey : IEquatable<Tkey> // Must be compareable
    {
        Task<IEnumerable<TEntity>> GetAllOrderedAsync(Tkey? userId = default, bool noTracking = true);
        Task<TEntity?> FirstOrDefaultAsync(Tkey id, Tkey? userId = default, bool noTracking = true);

        Task<TEntity?> FirstOrDefaultWithoutIncludesAsync(Tkey id, Tkey? userId = default, bool noTracking = true);
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Remove(TEntity entity, Tkey? userId = default);
        Task<TEntity> RemoveAsync(Tkey id, Tkey? userId = default);
        Task<bool> ExistsAsync(Tkey id, Tkey? userId = default);
    }
}