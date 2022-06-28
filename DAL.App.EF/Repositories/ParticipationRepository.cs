using AutoMapper;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;

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
}