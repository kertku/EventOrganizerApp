using System;
using Contracts.DAL.Base.Repositories;
using Contracts.Domain.Base;

namespace Contracts.BLL.Base.Services;
/*
*  public interface IBaseRepository<TEntity> : IBaseRepository<TEntity, Guid>
where TEntity : class, IDomainEntityId
{
}
*/
//Our BaseService shall implement same methods as IBaseRepository

public interface IBaseEntityService<TBllEntity, TDalEntity> : IBaseEntityService<TBllEntity, TDalEntity, Guid>
    where TBllEntity : class, IDomainEntityId<Guid>
    where TDalEntity : class, IDomainEntityId
{
}

public interface IBaseEntityService<TBllEntity, TDalEntity, TKey> : IBaseService,
    IBaseRepository<TBllEntity, TKey>
    where TBllEntity : class, IDomainEntityId<TKey>
    where TDalEntity : class, IDomainEntityId<TKey>
    where TKey : IEquatable<TKey> // Must be compareable
{
}