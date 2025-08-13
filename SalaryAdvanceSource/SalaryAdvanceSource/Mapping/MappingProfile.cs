using AutoMapper;
using SalaryAdvanceSource.DTOs;
using SalaryAdvanceSource.Models;

namespace SalaryAdvanceSource.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Users, GetUserDto>();
            CreateMap<Departments, GetDepartmentDto>();
            CreateMap<Users, CreateUserDto>();
            CreateMap<Information, GetInfo>();
        }
    }
}
