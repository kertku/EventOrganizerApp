using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories;


public interface IEventRepository: IBaseRepository<Event,Guid>,
IEventRepositoryCustom<Event>
{
}
public interface IEventRepositoryCustom<TEntity>
{
}