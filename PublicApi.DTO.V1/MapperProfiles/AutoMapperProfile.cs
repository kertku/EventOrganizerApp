using AutoMapper;
using DAL.App.DTO;

namespace PublicApi.Dto.v1.MapperProfiles;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Event, Events.Events>().ForMember(p => p.Participates,
            opt => opt
                .MapFrom(p => p.Participations!.Where(i => i.IndividualUser != null)
                    .Select(n => n.IndividualUser!.FullName)));
    }
}