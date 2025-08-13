using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using SalaryAdvanceSource.Data;
using SalaryAdvanceSource.DTOs;
using SalaryAdvanceSource.Exceptions;
using SalaryAdvanceSource.Extensions;
using SalaryAdvanceSource.Models;

namespace SalaryAdvanceSource.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly Idpsalary _context;
        private readonly IMapper _mapper;
        private readonly AuthenticationStateProvider _authStateProvider;
        public EmployeesService(Idpsalary context, IMapper mapper, AuthenticationStateProvider authStateProvider)
        {
            _context = context;
            _mapper = mapper;
            _authStateProvider = authStateProvider;
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
        public async Task CreateUserAsync(CreateUserDto userDto, string password)
        {
            var authState = await _authStateProvider.GetAuthenticationStateAsync();
            var userId = authState.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            var users = await _context.Users.ToListAsync();
            if (users.Any(u => u.UserName == userDto.UserName))
                throw new BusinessException("Username already exists");

            userDto.DateOfBirth = DateTime.SpecifyKind(userDto.DateOfBirth, DateTimeKind.Utc);
            userDto.OnboardDate = DateTime.SpecifyKind(userDto.OnboardDate, DateTimeKind.Utc);

            var user = new Users(userDto.UserName, password, Guid.Parse("550e8400-e29b-41d4-a716-446655440000"));

            user.SetFullName(userDto.FullName);
            user.SetEmail(userDto.Email);
            user.SetPhoneNumber(userDto.PhoneNumber);
            user.SetAddress(userDto.Address);
            user.SetDateOfBirth(userDto.DateOfBirth);
            user.SetGender(userDto.Gender);
            user.SetRole(userDto.Role);
            user.SetJob(userDto.Job);
            user.SetDepartmentName(userDto.DepartmentName);
            user.SetManagerId(userDto.ManagerId);
            user.SetOnboardDate(userDto.OnboardDate);
            user.SetBasicSalary(userDto.BasicSalary);
            user.SetIsActive(userDto.IsActive);

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        public async Task<CreateUserDto> GetUserByIdAsync(Guid userId)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserId == userId);
            return _mapper.Map<CreateUserDto>(user);
        }
        public async Task UpdateUserAsync(CreateUserDto userUpdate, Guid id)
        {
            userUpdate.DateOfBirth = DateTime.SpecifyKind(userUpdate.DateOfBirth, DateTimeKind.Utc);
            userUpdate.OnboardDate = DateTime.SpecifyKind(userUpdate.OnboardDate, DateTimeKind.Utc);

            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
            if (user == null)
                throw new Exception("User doesn't exist");

            user.SetRole(userUpdate.Role);
            user.SetJob(userUpdate.Job);
            user.SetDepartmentName(userUpdate.DepartmentName);
            user.SetManagerId(userUpdate.ManagerId);
            user.SetOnboardDate(userUpdate.OnboardDate);
            user.SetBasicSalary(userUpdate.BasicSalary);
            user.SetIsActive(userUpdate.IsActive);

            await _context.SaveChangesAsync();
        }
        public async Task DeleteUserAsync(Guid userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
            if (user == null)
                throw new BusinessException("User doesn't exist");
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
        public async Task<PagedResultDto<GetUserDto>> GetUsersAsync(PagedRequestDto request)
        {
            var query = _context.Users.AsNoTracking();

            var filteredQuery = await query.ToPagedResultAsync(
                request,
                u => u.UserName!,
                u => u.FullName!,
                u => u.Email!,
                u => u.PhoneNumber!
            );

            var dtoItems = _mapper.Map<List<GetUserDto>>(filteredQuery.Items);

            return new PagedResultDto<GetUserDto>
            {
                Items = dtoItems,
                TotalCount = filteredQuery.TotalCount
            };
        }
        public async Task<List<GetUserDto>> GetListManagerByDep(string groupCode)
        {
            var managers = await _context.Users
                .Where(u => u.Role == RoleType.Manager && u.DepartmentName == groupCode)
                .ToListAsync();
            return _mapper.Map<List<GetUserDto>>(managers);
        }
    }
}
