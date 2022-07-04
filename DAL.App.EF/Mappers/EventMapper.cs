using AutoMapper;
using Contracts.DAL.Base.Mappers;
using DAL.App.DTO;

namespace DAL.App.EF.Mappers;

public class EventMapper : BaseMapper<Event, Domain.App.Event>,
    IBaseMapper<Event, Domain.App.Event>
{
    public EventMapper(IMapper mapper) : base(mapper)
    {
    }
}