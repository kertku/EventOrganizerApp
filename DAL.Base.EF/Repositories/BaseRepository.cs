using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.Base.Mappers;
using Contracts.DAL.Base.Repositories;
using Contracts.Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace DAL.Base.EF.Repositories;

public class BaseRepository<TDalEntity, TDomainEntity, TDbContext> :
    BaseRepository<TDalEntity, TDomainEntity, Guid, TDbContext>,
    IBaseRepository<TDalEntity>
    where TDalEntity : class, IDomainEntityId
    where TDomainEntity : class, IDomainEntityId
    where TDbContext : DbContext
{
    public BaseRepository(TDbContext dbContext, IBaseMapper<TDalEntity, TDomainEntity> mapper) : base(dbContext,
        mapper)
    {
    }
}

public class
    BaseRepository<TDalEntity, TDomainEntity, TKey, TDbContext> : IBaseRepository<TDalEntity, TKey>
    where TDalEntity : class, IDomainEntityId<TKey>
    where TDomainEntity : class, IDomainEntityId<TKey>
    where TKey : IEquatable<TKey>
    where TDbContext : DbContext
{
    private readonly Dictionary<TDalEntity, TDomainEntity> _entityCache = new();
    protected readonly IBaseMapper<TDalEntity, TDomainEntity> Mapper;
    protected readonly TDbContext RepoDbContext;
    protected readonly DbSet<TDomainEntity> RepoDbSet;


    public BaseRepository(TDbContext dbContext, IBaseMapper<TDalEntity, TDomainEntity> mapper)
    {
        RepoDbContext = dbContext;
        Mapper = mapper;
        RepoDbSet = dbContext.Set<TDomainEntity>();
    }


    public virtual async Task<IEnumerable<TDalEntity>> GetAllOrderedAsync(TKey? userId = default,
        bool noTracking = true)
    {
        var query = CreateQuery(userId, noTracking);
        var resQuery = query.Select(domainEntity => Mapper.Map(domainEntity));
        var result = await resQuery.ToListAsync();

        return result!;
    }

    public virtual async Task<TDalEntity?> FirstOrDefaultAsync(TKey id, TKey? userId, bool noTracking = false)
    {
        var query = CreateQuery(userId, noTracking);

        return Mapper.Map(await query.FirstOrDefaultAsync(e => e!.Id.Equals(id)));
    }

    public virtual async Task<TDalEntity?> FirstOrDefaultWithoutIncludesAsync(TKey id, TKey? userId,
        bool noTracking = false)
    {
        var query = CreateQuery(userId, noTracking);

        return Mapper.Map(await query.FirstOrDefaultAsync(e => e!.Id.Equals(id)));
    }


    public virtual TDalEntity Add(TDalEntity entity)
    {
        var domainEntity = Mapper.Map(entity)!;
        var updatedDomainEntity = RepoDbSet.Add(domainEntity).Entity;
        var dalEntity = Mapper.Map(updatedDomainEntity)!;

        _entityCache.Add(entity, domainEntity);
        return dalEntity;
    }

    public virtual TDalEntity Update(TDalEntity entity)
    {
        return Mapper.Map(RepoDbSet.Update(Mapper.Map(entity)!).Entity)!;
    }


    public virtual TDalEntity Remove(TDalEntity entity, TKey? userId = default)
    {
        var domainEntity = Mapper.Map(entity)!;
        var updatedDomainEntity = RepoDbSet.Remove(domainEntity).Entity;
        var dalEntity = Mapper.Map(updatedDomainEntity)!;

        _entityCache.Add(entity, domainEntity); // Cache for the ID

        return dalEntity;
    }

    public virtual async Task<TDalEntity> RemoveAsync(TKey id, TKey? userId)
    {
        var entity = await FirstOrDefaultWithoutIncludesAsync(id, userId);
        RepoDbContext.ChangeTracker.Clear();

        if (entity == null) throw new NullReferenceException("Entity with id {id} not found!");

        Remove(entity);
        return entity;
    }


    public virtual async Task<bool> ExistsAsync(TKey id, TKey? userId = default)
    {
        return await RepoDbSet.AnyAsync(e =>
            // ReSharper disable once SuspiciousTypeConversion.Global
            e.Id.Equals(id));
    }


    public IQueryable<TDomainEntity> CreateQuery(TKey? userId, bool noTracking = true)
    {
        var query = RepoDbSet.AsQueryable();


        if (noTracking) query.AsNoTracking();

        return query;
    }
}