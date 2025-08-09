using SalaryAdvanceSource.Models;

namespace SalaryAdvanceSource.DTOs
{
    public class PostUserDto
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Guid DepartmentId { get; set; }
        public Guid ManagerId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public GenderType Gender { get; set; }
        public RoleType Role { get; set; }
        public PositionType Position { get; set; }
        public DateTime OnboardDate { get; set; }
        public decimal BasicSalary { get; set; }
    }

}
