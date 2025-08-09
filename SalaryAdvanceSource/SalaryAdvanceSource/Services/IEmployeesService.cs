using SalaryAdvanceSource.DTOs;

namespace SalaryAdvanceSource.Services
{
    public interface IEmployeesService
    {
        Task<List<GetUserDto>> GetAllUsersAsync();
    }
}
