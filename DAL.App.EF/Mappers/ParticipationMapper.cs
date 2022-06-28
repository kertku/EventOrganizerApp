using AutoMapper;
using Contracts.DAL.Base.Mappers;
using DAL.App.DTO;

namespace DAL.App.EF.Mappers;

public class ParticipationMapper : BaseMapper<Participation, Domain.App.Participation>,
    IBaseMapper<Participation, Domain.App.Participation>
{
    public ParticipationMapper(IMapper mapper) : base(mapper)
    {
    }
}