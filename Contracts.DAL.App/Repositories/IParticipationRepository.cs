using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories;

public interface IParticipationRepository : IBaseRepository<Participation, Guid>,
    IParticipationRepositoryCustom<Participation>
{
}

public interface IParticipationRepositoryCustom<TEntity>
{
}