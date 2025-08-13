using SalaryAdvanceSource.DTOs;

namespace SalaryAdvanceSource.Services
{
    public interface ISalaryLimitService
    {
        Task CreateLimitAsync(CreateLimitDto createLimitDto);
    }
}
