using AutoMapper;
using Herfitk.API.DTO;
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
                .ForMember(e => e.PersonalImage, e => e.MapFrom(e => e.HerfiyUser.PersonalImage))
                .ForMember(e => e.ImageWork, e => e.MapFrom(e => e.Image));

            CreateMap<HerifyCategory, HerifyDto>()
               .ForMember(e => e.DisplayImage, e => e.MapFrom(e => e.Herify.HerfiyUser.PersonalImage))
               .ForMember(e => e.Zone, e => e.MapFrom(e => e.Herify.Zone))
               .ForMember(e => e.History, e => e.MapFrom(e => e.Herify.History))
               .ForMember(e => e.Speciality, e => e.MapFrom(e => e.Herify.Speciality));

            CreateMap<Staff, StaffDto>()
                .ForMember(s => s.Id, s => s.MapFrom(s => s.StaffUser.Id))
                .ForMember(s => s.Address, s => s.MapFrom(s => s.StaffUser.Address))
                .ForMember(s => s.NationalId, s => s.MapFrom(s => s.StaffUser.NationalId))
                .ForMember(s => s.HireDate, s => s.MapFrom(s => s.StaffUser.UserStaff.HireDate))
                .ForMember(s => s.PersonalImage, s => s.MapFrom(s => s.StaffUser.PersonalImage))
                .ForMember(s => s.WorkHours, s => s.MapFrom(s => s.StaffUser.UserStaff.WorkHours))
                .ForMember(s => s.UserRole, s => s.MapFrom(s => s.StaffUser.Role));

            CreateMap<Client, ClientDto>().ReverseMap();

            CreateMap<ClientHerify, Herify_ReviewDto>()
                .ForMember(s => s.Review, s => s.MapFrom(s => s.ClientReview))
                .ForMember(s => s.Name, s => s.MapFrom(s => s.Client.ClientUser.DisplayName))
                .ForMember(s => s.ReviewDate, s => s.MapFrom(s => s.Date))
                .ForMember(s => s.Rate, s => s.MapFrom(s => s.Rate));
        }
    }
}