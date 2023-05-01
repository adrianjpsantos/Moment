using AutoMapper;
using Moment.Models.Entity;
using Moment.Models.EntityDto;

namespace AccountOwnerServer;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ConventionCategory, CategoryDto>();
        CreateMap<EventCreateView, Convention>();
        CreateMap<Convention, EventPageView>();
        CreateMap<Convention, EventEditView>();
        CreateMap<EventEditView, Convention>();
        CreateMap<UserInfoDto, UserInfo>();
    }

}