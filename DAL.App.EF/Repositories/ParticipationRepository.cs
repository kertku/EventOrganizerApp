using AutoMapper;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories;

public class ParticipationRepository : BaseRepository<Participation, Domain.App.Participation, AppDbContext>,
    IParticipationRepository
{
    private readonly IMapper _mapper;

    public ParticipationRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext,
        new ParticipationMapper(mapper))
    {
        _mapper = mapper;
    }



    public override async Task<Participation?> FirstOrDefaultAsync(Guid id, Guid userId = default, bool noTracking = true)
    {
        var query = RepoDbSet.AsQueryable();
        if (noTracking) query = query.AsNoTracking();

        query = query.Include(p => p.PaymentType)
            .Include(b => b.BusinessUser)
            .Include(e => e.Event)
            .Include(i => i.IndividualUser);

        var result = Mapper.Map(await query.FirstOrDefaultAsync(m => m.Id == id));
        return result;
    }
}    