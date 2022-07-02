using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories;

public interface IEventRepository : IBaseRepository<Event, Guid>,
    IEventRepositoryCustom<Event>
{
    Task<IEnumerable<Event>> GetAllWithParticipatesAsync(bool noTracking);
    Task<Event> GetEventWithParticipatesAsync(Guid id, bool noTracking);
}

public interface IEventRepositoryCustom<TEntity>
{
}