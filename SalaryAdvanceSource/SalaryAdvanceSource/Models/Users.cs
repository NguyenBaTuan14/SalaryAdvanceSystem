using System;
using System.ComponentModel.DataAnnotations;
using SalaryAdvanceSource.Utils;

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
    public enum ActiveStatus
    {
        Onboard = 0,
        Offline = 1,
        Online = 2,
        Orther = 3
    }

    public class Users
    {
        // ====== Properties ======
        [Key]
        public Guid UserId { get; private set; } = Guid.NewGuid();
        public string UserName { get; private set; } = string.Empty;
        public string Hash { get; private set; } = string.Empty;
        public string Salt { get; private set; } = string.Empty;
        public string DepartmentName { get; private set; } = string.Empty;
        public Guid ManagerId { get; private set; }
        public string FullName { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string PhoneNumber { get; private set; } = string.Empty;
        public string Address { get; private set; } = string.Empty;
        public DateTime DateOfBirth { get; private set; }
        public GenderType Gender { get; private set; }
        public RoleType Role { get; private set; }
        public string Job { get; private set; } = string.Empty;
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public Guid CreatedUserId { get; private set; }
        public DateTime OnboardDate { get; private set; }
        public decimal BasicSalary { get; private set; }
        public ActiveStatus IsActive { get; private set; }
        public string AvatarPath { get; set; } = string.Empty;

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
            var (hash, salt) = PasswordHasher.HashPassword(password);

            Hash = hash;
            Salt = salt;
        }

        public void SetDepartmentName(string departmentName)
        {
            if (departmentName == String.Empty)
                throw new ArgumentException("Department ID cannot be empty.", nameof(departmentName));
            DepartmentName = departmentName;
        }
        public void SetManagerId(Guid managerId)
        {
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
            DateOfBirth = dateOfBirth;
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
        public void SetJob(string job)
        {
            if (string.IsNullOrWhiteSpace(job))
                throw new ArgumentException("Position type not specified", nameof(job));
            Job = job;
        }
        public void SetOnboardDate(DateTime onboardDate)
        {
            if (onboardDate == default)
                throw new ArgumentException("Onboard date cannot be default value.", nameof(onboardDate));
            OnboardDate = onboardDate;
        }
        public void SetBasicSalary(decimal basicSalary)
        {
            if (basicSalary < 0)
                throw new ArgumentException("Basic salary cannot be negative.", nameof(basicSalary));
            BasicSalary = basicSalary;
        }
        public void SetIsActive(ActiveStatus isActive) => IsActive = isActive;
    }
}
