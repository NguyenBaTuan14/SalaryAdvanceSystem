using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using SalaryAdvanceSource.Data;
using SalaryAdvanceSource.DTOs;
using SalaryAdvanceSource.Models;

namespace SalaryAdvanceSource.Services
{
    public class LoginService : ILoginService
    {
        private readonly Idpsalary _context; // DbContext của bạn
        private readonly IWebHostEnvironment _env;

        public LoginService(Idpsalary context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<Users?> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == username && u.IsActive == ActiveStatus.Online);
        }
        public async Task<bool> UpdatePasswordAsync(Guid userId, string newPlainPassword)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId && u.IsActive == ActiveStatus.Online);
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

        public async Task<bool> UpdateUserProfileAsync(UpdateUserProfileDto userDto, Guid userId)
        {
            var userUpdate = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId && u.IsActive == ActiveStatus.Online);
            if (userUpdate == null)
                return false;
            userDto.DateOfBirth = DateTime.SpecifyKind(userDto.DateOfBirth, DateTimeKind.Utc);

            // SetPassword trong model đã hash sẵn, dùng method đó để tránh double-hash
            userUpdate.SetFullName(userDto.FullName);
            userUpdate.SetEmail(userDto.Email);
            userUpdate.SetPhoneNumber(userDto.PhoneNumber);
            userUpdate.SetAddress(userDto.Address);
            userUpdate.SetDateOfBirth(userDto.DateOfBirth);
            userUpdate.SetAvatarPath(userDto.AvatarPath);

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

        public async Task<string> UploadUserAvatarAsync(IBrowserFile file, Guid userId)
        {
            if (file == null)
                throw new ArgumentNullException(nameof(file));

            // Tạo thư mục lưu avatar
            string uploadFolder = Path.Combine(_env.WebRootPath, "uploads", "avatars");
            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            // Tạo tên file duy nhất
            string extension = Path.GetExtension(file.Name);
            string fileName = $"{userId}{extension}";
            string filePath = Path.Combine(uploadFolder, fileName);

            // Giới hạn kích thước tối đa 2MB
            var buffer = new byte[file.Size];
            await file.OpenReadStream(maxAllowedSize: 10 * 1024 * 1024).ReadAsync(buffer);
            await File.WriteAllBytesAsync(filePath, buffer);

            // Trả về đường dẫn để lưu DB
            return $"/uploads/avatars/{fileName}";
        }
    }
}
