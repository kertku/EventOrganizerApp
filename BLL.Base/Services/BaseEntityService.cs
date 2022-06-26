using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.Base.Services;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Mappers;
using Contracts.DAL.Base.Repositories;
using Contracts.Domain.Base;

namespace BLL.Base.Services
{
    public class BaseEntityService<TUnitOfWork, TRepository, TBllEntity, TDalEntity>
        : BaseEntityService<TUnitOfWork, TRepository, TBllEntity, TDalEntity, Guid>,
            IBaseEntityService<TBllEntity, TDalEntity>
        where TBllEntity : class, IDomainEntityId
        where TDalEntity : class, IDomainEntityId
        where TUnitOfWork : IBaseUnitOfWork
        where TRepository : IBaseRepository<TDalEntity, Guid>
    {
        public BaseEntityService(TUnitOfWork serviceUow, TRepository serviceRepository,
            IBaseMapper<TBllEntity, TDalEntity> mapper) : base(serviceUow, serviceRepository, mapper)
        {
        }
    }

    public class
        BaseEntityService<TUnitOfWork, TRepository, TBllEntity, TDalEntity, TKey> : IBaseEntityService<
            TBllEntity,
            TDalEntity, TKey>
        where TBllEntity : class, IDomainEntityId<TKey>
        where TDalEntity : class, IDomainEntityId<TKey>
        where TKey : IEquatable<TKey>
        where TUnitOfWork : IBaseUnitOfWork
        where TRepository : IBaseRepository<TDalEntity, TKey>


    {
        private readonly Dictionary<TBllEntity, TDalEntity> _entityCache = new();
        protected IBaseMapper<TBllEntity, TDalEntity> Mapper;
        protected TRepository ServiceRepository;
        protected TUnitOfWork ServiceUow;


        public BaseEntityService(TUnitOfWork serviceUow, TRepository serviceRepository,
            IBaseMapper<TBllEntity, TDalEntity> mapper)
        {
            ServiceUow = serviceUow;
            ServiceRepository = serviceRepository;
            Mapper = mapper;
        }


        public async Task<IEnumerable<TBllEntity>> GetAllAsync(TKey? userId = default, bool noTracking = true)
        {
            return (await ServiceRepository.GetAllAsync(userId, noTracking)).Select(entity => Mapper.Map(entity))!;
        }

        public async Task<TBllEntity?> FirstOrDefaultAsync(TKey id, TKey? userId = default, bool noTracking = true)
        {
            return Mapper.Map(await ServiceRepository.FirstOrDefaultAsync(id, userId, noTracking));
        }

        public async Task<TBllEntity?> FirstOrDefaultWithoutIncludesAsync(TKey id, TKey? userId = default,
            bool noTracking = true)
        {
            return Mapper.Map(await ServiceRepository.FirstOrDefaultWithoutIncludesAsync(id, userId, noTracking));
        }

        public virtual TBllEntity Add(TBllEntity entity)
        {
            var dalEntity = Mapper.Map(entity)!;
            var updatedDalEntity = ServiceRepository.Add(dalEntity);
            var returnBllEntity = Mapper.Map(updatedDalEntity)!;

            _entityCache.Add(entity, dalEntity);

            return returnBllEntity;
        }

        public TBllEntity Update(TBllEntity entity)
        {
            return Mapper.Map(ServiceRepository.Update(Mapper.Map(entity)!))!;
        }

        public TBllEntity Remove(TBllEntity entity, TKey? userId = default)
        {
            var dalEntity = Mapper.Map(entity)!;
            var updatedEntity = ServiceRepository.Update(dalEntity);
            var returnBllEntity = Mapper.Map(updatedEntity)!;
            _entityCache.Add(entity, dalEntity);
            return returnBllEntity;

            //return Mapper.Map(ServiceRepository.Remove(Mapper.Map(entity)!, userId))!;
        }


        public async Task<TBllEntity> RemoveAsync(TKey id, TKey? userId = default)
        {
            return Mapper.Map(await ServiceRepository.RemoveAsync(id, userId))!;
        }

        public Task<bool> ExistsAsync(TKey id, TKey? userId = default)
        {
            return ServiceRepository.ExistsAsync(id, userId);
        }
    }
}