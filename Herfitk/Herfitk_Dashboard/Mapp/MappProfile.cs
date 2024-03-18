using AutoMapper;
using Herfitk.API.DTO;
using Herfitk.Core.Models.Data;

namespace Herfitk_Dashboard.Mapp
{
    public class MappProfile : Profile
    {
        public MappProfile()
        {
            CreateMap<Herfiy, HerfiyReturnDto>()
               .ForMember(e => e.Name, e => e.MapFrom(e => e.HerfiyUser.DisplayName))
               .ForMember(e => e.Phone, e => e.MapFrom(e => e.HerfiyUser.PhoneNumber))
               .ForMember(e => e.PersonalImage, e => e.MapFrom(e => e.HerfiyUser.PersonalImage));

            CreateMap<HerfiyReturnDto, Herfiy>();
          
                
        }
       
    }
}
