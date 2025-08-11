using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SalaryAdvanceSource.Data;
using SalaryAdvanceSource.DTOs;
using SalaryAdvanceSource.Models;

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
        public async Task<GetUserDto> GetManagerAsync(Guid managerId)
        {
            var manager = await _context.Users
                .FirstOrDefaultAsync(u => u.UserId == managerId);
            return _mapper.Map<GetUserDto>(manager);
        }
        public async Task CreateUserAsync(CreateUserDto userDto)
        {
            userDto.DateOfBirth = DateTime.SpecifyKind(userDto.DateOfBirth, DateTimeKind.Utc);
            userDto.OnboardDate = DateTime.SpecifyKind(userDto.OnboardDate, DateTimeKind.Utc);

            var user = new Users(userDto.UserName, userDto.Password, Guid.Parse("9a754549-bad4-4f03-9bb1-6bb92ca98f00"));

            user.SetFullName(userDto.FullName);
            user.SetEmail(userDto.Email);
            user.SetPhoneNumber(userDto.PhoneNumber);
            user.SetAddress(userDto.Address);
            user.SetDateOfBirth(userDto.DateOfBirth);
            user.SetGender(userDto.Gender);
            user.SetRole(userDto.Role);
            user.SetPosition(userDto.Position);
            user.SetDepartmentId(userDto.DepartmentId);
            var department = await _context.Departments
                .FirstOrDefaultAsync(u => u.DepartmentId == userDto.DepartmentId);
            user.SetManagerId(department!.ManagerId);
            user.SetOnboardDate(userDto.OnboardDate);
            user.SetBasicSalary(userDto.BasicSalary);
            user.SetIsActive(true);

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        public async Task<CreateUserDto> GetUserByIdAsync(Guid userId)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserId == userId);
            return _mapper.Map<CreateUserDto>(user);
        }
        public async Task UpdateUserAsync(CreateUserDto userUpdate, Guid id, bool isActive)
        {
            userUpdate.DateOfBirth = DateTime.SpecifyKind(userUpdate.DateOfBirth, DateTimeKind.Utc);
            userUpdate.OnboardDate = DateTime.SpecifyKind(userUpdate.OnboardDate, DateTimeKind.Utc);

            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
            if (user == null)
                throw new Exception("User doesn't exist");

            user.SetFullName(userUpdate.FullName);
            user.SetEmail(userUpdate.Email);
            user.SetPhoneNumber(userUpdate.PhoneNumber);
            user.SetAddress(userUpdate.Address);
            user.SetDateOfBirth(userUpdate.DateOfBirth);
            user.SetGender(userUpdate.Gender);
            user.SetRole(userUpdate.Role);
            user.SetPosition(userUpdate.Position);
            user.SetDepartmentId(userUpdate.DepartmentId);
            var department = await _context.Departments
                .FirstOrDefaultAsync(d => d.DepartmentId == userUpdate.DepartmentId);
            user.SetManagerId(department!.ManagerId);
            user.SetOnboardDate(userUpdate.OnboardDate);
            user.SetBasicSalary(userUpdate.BasicSalary);
            user.SetIsActive(isActive);

            if (!string.IsNullOrWhiteSpace(userUpdate.Password))
            {
                user.SetPassword(userUpdate.Password);
            }

            await _context.SaveChangesAsync();
        }

    }
}
