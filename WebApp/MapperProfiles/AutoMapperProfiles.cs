using AutoMapper;
using DAL.App.DTO;
using WebApp.Models;
using WebApp.Models.Events;
using WebApp.Models.IndividualUsers;

namespace WebApp.MapperProfiles;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Event, Domain.App.Event>().ReverseMap();
        CreateMap<EventCreateEditViewModel, Domain.App.Event>().ReverseMap();
        CreateMap<EventCreateEditViewModel, Event>().ReverseMap();
        CreateMap<IndividualUser, IndividualUserViewModel>().ReverseMap();

        CreateMap<Event, EventDetailsViewVm>().ForMember(i => i.Participations,
                opt => opt
                    .MapFrom(p => p.Participations!))
            .ReverseMap();
    }
}