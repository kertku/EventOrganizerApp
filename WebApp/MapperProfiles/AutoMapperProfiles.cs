using AutoMapper;
using WebApp.Models;

namespace WebApp.MapperProfiles;

public class AutoMapperProfiles: Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<EventCreateEditViewModel, Domain.App.Event>().ReverseMap();
    }
}