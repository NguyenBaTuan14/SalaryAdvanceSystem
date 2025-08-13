using SalaryAdvanceSource.DTOs;

namespace SalaryAdvanceSource.Services
{
    public interface IEmployeesService
    {
        Task<List<GetUserDto>> GetAllUsersAsync();
        Task<GetUserDto> GetManagerAsync(Guid managerId);
        Task CreateUserAsync(CreateUserDto userDto);
        Task<CreateUserDto> GetUserByIdAsync(Guid userId);
        Task UpdateUserAsync(CreateUserDto userUpdate, Guid id);
        Task DeleteUserAsync(Guid userId);
        Task<PagedResultDto<GetUserDto>> GetUsersAsync(PagedRequestDto request);
        Task<List<GetUserDto>> GetListManager();
    }
}
