using AutoMapper;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;

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
    
    public override async Task<IEnumerable<Event>> GetAllAsync(Guid userId, bool noTracking)
    {
        var query = RepoDbSet.AsQueryable();

        if (noTracking) query = query.AsNoTracking();

        var resQuery = query.OrderBy(e=>e.Date).Select(x => Mapper.Map(x));

        var result = await resQuery.ToListAsync();

        return result!;
    }
}

