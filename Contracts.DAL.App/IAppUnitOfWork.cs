using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;

namespace Contracts.DAL.App;

public interface IAppUnitOfWork : IBaseUnitOfWork
{
    IBusinessUserRepository BusinessUser { get; }
    IEventRepository Event { get; }
    IIndividualUserRepository IndividualUser { get; }
    IParticipationRepository Participation { get; }
    IPaymentTypeRepository PaymentType { get; }
}