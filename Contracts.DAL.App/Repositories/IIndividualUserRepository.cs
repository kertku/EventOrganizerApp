using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories;

public interface IIndividualUserRepository: IBaseRepository<IndividualUser,Guid>,
    IIndividualUserRepositoryCustom<IndividualUser>
{
}
public interface IIndividualUserRepositoryCustom<TEntity>
{
}
