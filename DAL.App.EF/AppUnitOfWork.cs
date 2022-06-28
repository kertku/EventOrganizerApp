using AutoMapper;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Repositories;
using DAL.Base.EF;

namespace DAL.App.EF;

public class AppUnitOfWork : BaseUnitOfWork<AppDbContext>, IAppUnitOfWork
{
    protected IMapper Mapper;

    public AppUnitOfWork(AppDbContext uowDbContext, IMapper mapper) : base(uowDbContext)
    {
        Mapper = mapper;
    }

    public IBusinessUserRepository BusinessUser =>
        GetRepository(() => new BusinessUserRepository(UowDbContext, Mapper));

    public IEventRepository Event =>
        GetRepository(() => new EventRepository(UowDbContext, Mapper));

    public IIndividualUserRepository IndividualUser =>
        GetRepository(() => new IndividualUserRepository(UowDbContext, Mapper));

    public IParticipationRepository Participation =>
        GetRepository(() => new ParticipationRepository(UowDbContext, Mapper));

    public IPaymentTypeRepository PaymentType =>
        GetRepository(() => new PaymentTypeRepository(UowDbContext, Mapper));
}