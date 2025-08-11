using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SalaryAdvanceSource.Data;
using SalaryAdvanceSource.DTOs;

namespace SalaryAdvanceSource.Services
{
    public class DepartmentsService : IDepartmentsService
    {
        private readonly Idpsalary _context;
        private readonly IMapper _mapper;
        public DepartmentsService(Idpsalary context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<GetDepartmentDto>> GetAllDepartmentAsync()
        {
            var departments = await _context.Departments.ToListAsync();
            return _mapper.Map<List<GetDepartmentDto>>(departments);
        }
    }
}
