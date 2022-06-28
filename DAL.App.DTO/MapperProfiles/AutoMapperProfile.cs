using AutoMapper;


namespace DAL.App.DTO.MapperProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BusinessUser, Domain.App.BusinessUser>().ReverseMap();
            CreateMap<Event, Domain.App.Event>().ReverseMap();
            CreateMap<IndividualUser, Domain.App.IndividualUser>().ReverseMap();
            CreateMap<Participation, Domain.App.Participation>().ReverseMap();
            CreateMap<PaymentType, Domain.App.PaymentType>().ReverseMap();
        }
    }
}