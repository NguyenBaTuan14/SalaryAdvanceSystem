using AutoMapper;
using SalaryAdvanceSource.DTOs;
using SalaryAdvanceSource.Models;

namespace SalaryAdvanceSource.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Users, GetUserDto>()
                .ForMember(dest => dest.IsActive,
                           opt => opt.MapFrom(src => Enum.Parse<ActiveStatus>(src.IsActive.ToString())))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender));

            CreateMap<Departments, GetDepartmentDto>();
            CreateMap<Users, CreateUserDto>();
            CreateMap<Information, GetInfo>();
        }
    }
}
