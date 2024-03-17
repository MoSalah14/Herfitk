using AutoMapper;
using Herfitk.API.Dto;
using Herfitk.API.DTO;
using Herfitk.Core.Models;
using Herfitk.Core.Models.Data;

namespace Herfitk.API.Maping_Classes
{
    public class MappingClasses : Profile
    {
        public MappingClasses()
        {
            CreateMap<Herfiy, HerfiyReturnDto>()
                .ForMember(e => e.Name, e => e.MapFrom(e => e.HerfiyUser.DisplayName))
                .ForMember(e => e.Phone, e => e.MapFrom(e => e.HerfiyUser.PhoneNumber))
                .ForMember(e => e.PersonalImage, e => e.MapFrom(e => e.HerfiyUser.PersonalImage));


            CreateMap<HerifyDto, HerifyCategory>()
               .ForMember(e => e.Herify.HerfiyUser.PersonalImage, e => e.MapFrom(e => e.Image))
               .ForMember(e => e.Herify.Zone, e => e.MapFrom(e => e.Zone))
               .ForMember(e => e.Herify.History, e => e.MapFrom(e => e.History))
               .ForMember(e => e.Herify, e => e.MapFrom(e => e.Speciality));




        }
    }
}
