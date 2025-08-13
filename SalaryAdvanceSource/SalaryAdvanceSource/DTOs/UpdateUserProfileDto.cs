using SalaryAdvanceSource.Models;

namespace SalaryAdvanceSource.DTOs
{
    public class UpdateUserProfileDto
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get;  set; } = string.Empty;
        public DateTime DateOfBirth { get;  set; }
        public GenderType Gender { get;  set; }

        public string AvatarPath { get; set; } = string.Empty;

    }
}
