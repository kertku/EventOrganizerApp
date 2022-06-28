using AutoMapper;
using Contracts.DAL.Base.Mappers;
using DAL.App.DTO;

namespace DAL.App.EF.Mappers;

public class PaymentTypeMapper : BaseMapper<PaymentType, Domain.App.PaymentType>,
    IBaseMapper<PaymentType, Domain.App.PaymentType>
{
    public PaymentTypeMapper(IMapper mapper) : base(mapper)
    {
    }
}