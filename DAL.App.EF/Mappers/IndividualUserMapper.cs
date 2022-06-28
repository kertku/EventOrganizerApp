using AutoMapper;
using Contracts.DAL.Base.Mappers;
using DAL.App.DTO;

namespace DAL.App.EF.Mappers;

public class IndividualUserMapper : BaseMapper<IndividualUser, Domain.App.IndividualUser>,
    IBaseMapper<IndividualUser, Domain.App.IndividualUser>
{
    public IndividualUserMapper(IMapper mapper) : base(mapper)
    {
    }
}