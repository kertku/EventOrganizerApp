using AutoMapper;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;

namespace DAL.App.EF.Repositories;

public class BusinessUserRepository : BaseRepository<BusinessUser, Domain.App.BusinessUser, AppDbContext>,
    IBusinessUserRepository
{
    private readonly IMapper _mapper;

    public BusinessUserRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext,
        new BusinessUserMapper(mapper))
    {
        _mapper = mapper;
    }
}