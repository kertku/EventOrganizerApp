using AutoMapper;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;

namespace DAL.App.EF.Repositories;

public class PaymentTypeRepository : BaseRepository<PaymentType, Domain.App.PaymentType, AppDbContext>,
    IPaymentTypeRepository
{
    private readonly IMapper _mapper;

    public PaymentTypeRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext,
        new PaymentTypeMapper(mapper))
    {
        _mapper = mapper;
    }
}