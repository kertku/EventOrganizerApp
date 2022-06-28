using AutoMapper;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;

namespace DAL.App.EF.Repositories;

public class IndividualUserRepository: BaseRepository<IndividualUser, Domain.App.IndividualUser, AppDbContext>,
    IIndividualUserRepository
{
    private readonly IMapper _mapper;

    public IndividualUserRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext,
        new IndividualUserMapper(mapper))
    {
        _mapper = mapper;
    }
}