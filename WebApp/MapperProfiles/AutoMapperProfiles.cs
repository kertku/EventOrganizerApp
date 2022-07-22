using AutoMapper;
using DAL.App.DTO;
using WebApp.Models.Events;
using WebApp.Models.IndividualUsers;
using WebApp.Models.PaymentTypes;

namespace WebApp.MapperProfiles;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Domain.App.Event, Event>().ReverseMap();
        CreateMap<EventCreateEditViewModel, Domain.App.Event>().ReverseMap();
        CreateMap<EventCreateEditViewModel, Event>().ReverseMap();
        CreateMap<IndividualUser, IndividualUserViewModel>().ReverseMap();
        CreateMap<PaymentTypeVm, PaymentType>().ReverseMap();

        CreateMap<Event, EventDetailsViewVm>().ForMember(i => i.Participations,
                opt => opt
                    .MapFrom(p => p.Participations!))
            .ReverseMap();
    }
}