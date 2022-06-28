using AutoMapper;
using DAL.App.DTO;
using DAL.Base.EF.Repositories;

namespace DAL.App.EF.Repositories;

public class PaymentTypeRepository : BaseRepository<PaymentType, Domain.App.PaymentType, AppDbContext>,
    IHomeworkRepository
{
    
    private readonly IMapper _mapper;

    public HomeworkRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext,
        new HomeworkMapper(mapper))
    {
        _mapper = mapper;
    }

    public override async Task<IEnumerable<Homework>> GetAllAsync(Guid userId, bool noTracking)
    {
        var query = RepoDbSet.AsQueryable();

        if (noTracking) query = query.AsNoTracking();

        var resQuery = query.Include(s => s.Subject)
            .Select(x => Mapper.Map(x));

        var result = await resQuery.ToListAsync();

        return result!;
    }

    public override async Task<Homework?> FirstOrDefaultAsync(Guid id, Guid userId, bool noTracking)
    {
        var query = RepoDbSet.AsQueryable();

        if (noTracking) query = query.AsNoTracking();

        var resQuery = query.Include(s => s.Subject);

        var result = Mapper.Map(await resQuery.FirstOrDefaultAsync(m => m.Id == id));

        return result;
    }

    public async Task<IEnumerable<Homework>> GetAllWithStatisticAsync(bool noTracking = true)
    {
        var query = RepoDbSet.AsQueryable();

        if (noTracking) query = query.AsNoTracking();

        var resQuery = query.Include(h => h.HomeworkInDeclarations)
            .Include(s => s.Subject)
            .Select(hw => new Homework()
            {
                HomeworkName = hw.HomeworkName,
                CreationTime = hw.CreationTime,
                DeletedAt = hw.DeletedAt,
                HomeworkInfo = hw.HomeworkInfo,
                TotalAttended = hw.HomeworkInDeclarations!.Count,
                AverageGrade = hw.HomeworkInDeclarations!.Select(r => r.Grade).Average(),
                Id = hw.Id,
                SubjectId = hw.SubjectId,
                Subject = _mapper.Map<DAL.App.DTO.Subject>(hw.Subject)
            });

        var result = await resQuery.ToListAsync();

        return result!;
    }
}