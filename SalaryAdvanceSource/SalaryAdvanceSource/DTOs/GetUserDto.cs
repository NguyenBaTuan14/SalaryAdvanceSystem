using SalaryAdvanceSource.Models;

namespace SalaryAdvanceSource.DTOs
{
    public class GetUserDto
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? DepartmentName { get; set; }
        public Guid ManagerId { get; set; }
        public GenderType Gender { get; set; }
        public RoleType Role { get; set; }
        public string? Job { get; set; }
        public DateTime CreatedAt { get; set; }
        public ActiveStatus IsActive { get; set; }
    }
}
