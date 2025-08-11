using System;
using System.ComponentModel.DataAnnotations;

namespace SalaryAdvanceSource.Models
{
    public enum GenderType
    {
        Unknown = 0,
        Female = 1,
        Male = 2,
    }

    public enum RoleType
    {
        Employee = 0,
        Manager = 1,
    }

    public enum PositionType
    {
        Unknown = 0,
        Developer = 1,
        Designer = 2,
        Tester = 3,
        Manager = 4,
        HR = 5,
        Sales = 6,
    }

    public class Users
    {
        // ====== Properties ======
        [Key]
        public Guid UserId { get; private set; } = Guid.NewGuid();
        public string UserName { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;
        public Guid DepartmentId { get; private set; }
        public Guid ManagerId { get; private set; }
        public string FullName { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string PhoneNumber { get; private set; } = string.Empty;
        public string Address { get; private set; } = string.Empty;
        public DateTime DateOfBirth { get; private set; }
        public GenderType Gender { get; private set; }
        public RoleType Role { get; private set; }
        public PositionType Position { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public Guid CreatedUserId { get; private set; }
        public DateTime OnboardDate { get; private set; }
        public decimal BasicSalary { get; private set; }
        public bool IsActive { get; private set; } = true;

        // ====== Constructors ======
        private Users() { }
        public Users(string userName, string password, Guid createdUserId)
        {
            SetUserName(userName);
            SetPassword(password);
            CreatedUserId = createdUserId;
        }

        public void SetUserName(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentException("User name cannot be null or empty.", nameof(userName));
            UserName = userName;
        }
        public void SetPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password cannot be null or empty.", nameof(password));
            Password = BCrypt.Net.BCrypt.HashPassword(password);
        }
        public void SetDepartmentId(Guid departmentId)
        {
            if (departmentId == Guid.Empty)
                throw new ArgumentException("Department ID cannot be empty.", nameof(departmentId));
            DepartmentId = departmentId;
        }
        public void SetManagerId(Guid managerId)
        {
            if (managerId == Guid.Empty)
                throw new ArgumentException("Manager ID cannot be empty.", nameof(managerId));
            ManagerId = managerId;
        }
        public void SetFullName(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("Full name cannot be null or empty.", nameof(fullName));
            FullName = fullName;
        }
        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be null or empty.", nameof(email));
            Email = email;
        }
        public void SetPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentException("Phone number cannot be null or empty.", nameof(phoneNumber));
            PhoneNumber = phoneNumber;
        }
        public void SetAddress(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException("Address cannot be null or empty.", nameof(address));
            Address = address;
        }
        public void SetDateOfBirth(DateTime dateOfBirth)
        {
            if (dateOfBirth == default)
                throw new ArgumentException("Date of birth cannot be default value.", nameof(dateOfBirth));
            DateOfBirth = DateTime.SpecifyKind(dateOfBirth, DateTimeKind.Utc);
        }
        public void SetGender(GenderType gender)
        {
            if (!Enum.IsDefined(typeof(GenderType), gender))
                throw new ArgumentException("Gender type not specified", nameof(gender));
            Gender = gender;
        }
        public void SetRole(RoleType role)
        {
            if (!Enum.IsDefined(typeof(RoleType), role))
                throw new ArgumentException("User role not specified", nameof(role));
            Role = role;
        }
        public void SetPosition(PositionType position)
        {
            if (!Enum.IsDefined(typeof(PositionType), position))
                throw new ArgumentException("Position type not specified", nameof(position));
            Position = position;
        }
        public void SetOnboardDate(DateTime onboardDate)
        {
            if (onboardDate == default)
                throw new ArgumentException("Onboard date cannot be default value.", nameof(onboardDate));
            OnboardDate = DateTime.SpecifyKind(onboardDate, DateTimeKind.Utc);
        }
        public void SetBasicSalary(decimal basicSalary)
        {
            if (basicSalary < 0)
                throw new ArgumentException("Basic salary cannot be negative.", nameof(basicSalary));
            BasicSalary = basicSalary;
        }
        public void SetIsActive(bool isActive) => IsActive = isActive;
    }
}
