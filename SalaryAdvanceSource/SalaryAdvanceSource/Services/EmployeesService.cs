using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SalaryAdvanceSource.Data;
using SalaryAdvanceSource.DTOs;

namespace SalaryAdvanceSource.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly Idpsalary _context;
        private readonly IMapper _mapper;
        public EmployeesService(Idpsalary context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<GetUserDto>> GetAllUsersAsync()
        {
            var users = await _context.Users.ToListAsync();
            return _mapper.Map<List<GetUserDto>>(users);
        }
    }
}
