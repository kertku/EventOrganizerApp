using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories;

public interface IBusinessUserRepository : IBaseRepository<BusinessUser, Guid>,
    IBusinessUserRepositoryCustom<Event>
{
}

public interface IBusinessUserRepositoryCustom<TEntity>
{
}