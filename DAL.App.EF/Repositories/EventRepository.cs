using AutoMapper;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;

namespace DAL.App.EF.Repositories;

public class EventRepository : BaseRepository<Event, Domain.App.Event, AppDbContext>,
    IEventRepository
{
    private readonly IMapper _mapper;

    public EventRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext,
        new EventMapper(mapper))
    {
        _mapper = mapper;
    }
}

