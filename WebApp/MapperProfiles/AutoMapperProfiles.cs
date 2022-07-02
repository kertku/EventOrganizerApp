using AutoMapper;
using DAL.App.DTO;
using WebApp.Models;
using WebApp.Models.Events;

namespace WebApp.MapperProfiles;

public class AutoMapperProfiles: Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<EventCreateEditViewModel, Domain.App.Event>().ReverseMap();
        
        CreateMap<Event, EventDetailsViewVm>().ForMember(i => i.Participations,
            opt => opt
                .MapFrom(p => p.Participations!)).ReverseMap();
        

        
    }
}