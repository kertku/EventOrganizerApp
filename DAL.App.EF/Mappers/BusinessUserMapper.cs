using AutoMapper;
using Contracts.DAL.Base.Mappers;
using DAL.App.DTO;

namespace DAL.App.EF.Mappers;

public class BusinessUserMapper: BaseMapper<BusinessUser, Domain.App.BusinessUser>,
    IBaseMapper<BusinessUser, Domain.App.BusinessUser>
{
    public BusinessUserMapper(IMapper mapper) : base(mapper)
    {
    }
}