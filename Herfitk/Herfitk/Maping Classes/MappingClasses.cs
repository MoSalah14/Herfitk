using AutoMapper;
using Herfitk.API.DTO;
using Herfitk.Models;

namespace Herfitk.API.Maping_Classes
{
    public class MappingClasses : Profile
    {
        public MappingClasses()
        {
            CreateMap<Herfiy, HerfiyDto>()
                .ForMember(e => e.Name, e => e.MapFrom(e => e.User.DisplayName))
                .ForMember(e => e.Phone, e => e.MapFrom(e => e.User.PhoneNumber))
                .ForMember(e => e.PersonalImage, e => e.MapFrom(e => e.User.PersonalImage));

        }
    }
}
