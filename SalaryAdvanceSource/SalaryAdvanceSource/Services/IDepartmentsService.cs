using SalaryAdvanceSource.DTOs;

namespace SalaryAdvanceSource.Services
{
    public interface IDepartmentsService
    {
        Task<List<GetDepartmentDto>> GetAllDepartmentAsync();
    }
}
