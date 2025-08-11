using SalaryAdvanceSource.Models;
using System.ComponentModel.DataAnnotations;

namespace SalaryAdvanceSource.DTOs
{
    public class CreateUserDto
    {
        [Required(ErrorMessage = "Please enter username")]
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Guid DepartmentId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public GenderType Gender { get; set; } = GenderType.Unknown;
        public RoleType Role { get; set; } = RoleType.Employee;
        public PositionType Position { get; set; } = PositionType.Unknown;
        public DateTime OnboardDate { get; set; } = DateTime.UtcNow;
        public decimal BasicSalary { get; set; } = 0;
    }

}
