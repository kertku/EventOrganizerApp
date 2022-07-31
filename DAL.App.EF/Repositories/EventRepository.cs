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

    public override async Task<Event?> FirstOrDefaultAsync(Guid id, Guid userId, bool noTracking = false)
    {
        var query = RepoDbSet.AsQueryable();
        if (noTracking) query = query.AsNoTracking();
        var resQuery = await query.Include(p => p.Participations)!
            .ThenInclude(i => i.IndividualUser)
            .Include(p => p.Participations)!
            .ThenInclude(b => b.BusinessUser).FirstOrDefaultAsync(e => e.Id == id);

        var eventObj = _mapper.Map<Event>(resQuery);
        if (eventObj.Participations.Any())
        {
            var participationCount = eventObj.Participations.Sum(i => i.NumberOfParticipants);
            eventObj.ParticipationCount = participationCount;
        }


        return eventObj;
    }

    public override async Task<IEnumerable<Event>> GetAllOrderedAsync(Guid userId = default, bool noTracking = true)
    {
        var query = RepoDbSet.AsQueryable();
        if (noTracking) query = query.AsNoTracking();
        var resQuery = query.Include(p => p.Participations)!
            .ThenInclude(i => i.IndividualUser)
            .Include(p => p.Participations)!
            .ThenInclude(b => b.BusinessUser).OrderBy(e => e.Date)
            .Select(x =>
                new Event
                {
                    Id = x.Id,
                    Date = x.Date,
                    Information = x.Information,
                    Location = x.Location,
                    Name = x.Name,
                    ParticipationCount = x.Participations!.Sum(i => i.NumberOfParticipants),
                    Participations = _mapper.Map<ICollection<Participation>>(x.Participations)
                });
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

    public async Task<Event> GetEventWithParticipatesAsync(Guid id, bool noTracking)
    {
        var query = RepoDbSet.AsQueryable();
        if (noTracking) query = query.AsNoTracking();
        query = query.Include(p => p.Participations)!
                .ThenInclude(i => i.IndividualUser)
                .Include(p => p.Participations)!
                .ThenInclude(b => b.BusinessUser)
            ;
        var result = Mapper.Map(await query.FirstOrDefaultAsync(e => e.Id == id));

        return result!;
    }

    public Task<string?> GetAllWithParticipatesAsync()
    {
        throw new NotImplementedException();
    }
}