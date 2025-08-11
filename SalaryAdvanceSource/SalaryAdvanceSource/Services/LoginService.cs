using Microsoft.EntityFrameworkCore;
using SalaryAdvanceSource.Data;
using SalaryAdvanceSource.Models;

namespace SalaryAdvanceSource.Services
{
    public class LoginService: ILoginService
    {
        private readonly Idpsalary _context; // DbContext của bạn

        public LoginService(Idpsalary context)
        {
            _context = context;
        }

        public async Task<Users?> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == username && u.IsActive);
        }
        public async Task<bool> UpdatePasswordAsync(Guid userId, string newPlainPassword)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId && u.IsActive);
            if (user == null)
                return false;

            // SetPassword trong model đã hash sẵn, dùng method đó để tránh double-hash
            user.SetPassword(newPlainPassword);

            try
            {
                // Save chỉ thay đổi property password (EF sẽ phát hiện)
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                // Log nếu cần
                return false;
            }
        }
    }
}
