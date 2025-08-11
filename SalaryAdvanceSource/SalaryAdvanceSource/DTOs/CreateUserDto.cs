using SalaryAdvanceSource.Models;
using System.ComponentModel.DataAnnotations;

namespace SalaryAdvanceSource.DTOs
{
    public class CreateUserDto
    {
        [Required(ErrorMessage = "Please enter username")]
        [MaxLength(100, ErrorMessage = "Username cannot exceed 100 characters")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter password")]
        public string Password { get; set; } = string.Empty;
        
        public Guid DepartmentId { get; set; }

        [Required(ErrorMessage = "Please enter full name")]
        [MaxLength(150, ErrorMessage = "Full name cannot exceed 150 characters")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter email")]
        [MaxLength(150, ErrorMessage = "Email cannot exceed 150 characters")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter phone number")]
        [MaxLength(50, ErrorMessage = "Phone number cannot exceed 50 characters")]
        [Phone(ErrorMessage = "Invalid phone number format")]
        public string PhoneNumber { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; } = DateTime.UtcNow;

        [Required(ErrorMessage = "Please select gender")]
        public GenderType Gender { get; set; } = GenderType.Unknown;

        [Required(ErrorMessage = "Please select role")]
        public RoleType Role { get; set; } = RoleType.Employee;

        [Required(ErrorMessage = "Please select position")]
        public PositionType Position { get; set; } = PositionType.Unknown;

        public DateTime OnboardDate { get; set; } = DateTime.UtcNow;

        [Required(ErrorMessage = "Please enter basic salary")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Basic salary must be greater than 0")]
        public decimal BasicSalary { get; set; } = 0;

        public bool IsActive { get; set; } = true;
    }

}
