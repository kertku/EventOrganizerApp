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

    public override async Task<IEnumerable<Event>> GetAllOrderedAsync(Guid userId, bool noTracking)
    {
        var query = RepoDbSet.AsQueryable();
        if (noTracking) query = query.AsNoTracking();
        var resQuery = query.OrderBy(e => e.Date)
            .Select(x => Mapper.Map(x));
        var result = await resQuery.ToListAsync();
        return result!;
    }


    public async Task<IEnumerable<Event>> GetAllWithParticipatesAsync(bool noTracking)
    {
        var query = RepoDbSet.AsQueryable();
        if (noTracking) query = query.AsNoTracking();
        var resQuery = query.Include(p => p.Participations)!
            .ThenInclude(i => i.IndividualUser)
            .Include(p => p.Participations)!
            .ThenInclude(b => b.BusinessUser)
            .Select(x => Mapper.Map(x));
        var result = await resQuery.ToListAsync();
        return result!;
    }

    public async Task<Event> GetEventWithParticipatesAsync(Guid id,bool noTracking)
    {
        var query = RepoDbSet.AsQueryable();
        if (noTracking) query = query.AsNoTracking();
       query = query.Include(p => p.Participations)!
            .ThenInclude(i => i.IndividualUser)
            .Include(p => p.Participations)!
            .ThenInclude(b => b.BusinessUser)
            ;
        var result = Mapper.Map(await query.FirstOrDefaultAsync(e=>e.Id == id) );
        return result!;
    }

    public Task<string?> GetAllWithParticipatesAsync()
    {
        throw new NotImplementedException();
    }
}