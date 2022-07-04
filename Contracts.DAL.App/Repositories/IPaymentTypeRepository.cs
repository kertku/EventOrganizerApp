using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories;

public interface IPaymentTypeRepository : IBaseRepository<PaymentType, Guid>,
    IPaymentTypeRepositoryCustom<PaymentType>
{
}

public interface IPaymentTypeRepositoryCustom<TEntity>
{
}