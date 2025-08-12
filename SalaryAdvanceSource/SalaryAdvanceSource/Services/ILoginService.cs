using SalaryAdvanceSource.Models;

namespace SalaryAdvanceSource.Services
{
    public interface ILoginService
    {
        Task<Users?> GetUserByUsernameAsync(string username);
        Task<bool> UpdatePasswordAsync(Guid userId, string newPlainPassword);
    }
}
