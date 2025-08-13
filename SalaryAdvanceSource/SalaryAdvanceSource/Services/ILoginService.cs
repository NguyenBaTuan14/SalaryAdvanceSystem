using Microsoft.AspNetCore.Components.Forms;
using SalaryAdvanceSource.DTOs;
using SalaryAdvanceSource.Models;

namespace SalaryAdvanceSource.Services
{
    public interface ILoginService
    {
        Task<Users?> GetUserByUsernameAsync(string username);
        Task<bool> UpdatePasswordAsync(Guid userId, string newPlainPassword);
        Task<bool> UpdateUserProfileAsync(UpdateUserProfileDto userDto, Guid userId);
        Task<string> UploadUserAvatarAsync(IBrowserFile file, Guid userId);
    }
}
