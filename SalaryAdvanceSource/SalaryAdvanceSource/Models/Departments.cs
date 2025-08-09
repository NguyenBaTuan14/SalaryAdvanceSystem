using System.ComponentModel.DataAnnotations;

namespace SalaryAdvanceSource.Models
{
    public class Departments
    {
        // ====== Properties ======
        [Key]
        public Guid DepartmentId { get; private set; } = Guid.NewGuid();
        public string DepartmentName { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public Guid ManagerId { get; private set; }

        // ====== Constructors ======
        private Departments() { }
        public Departments(string departmentName, string description, Guid managerId)
        {
            SetDepartmentName(departmentName);
            SetDescription(description);
            ManagerId = managerId;
        }
        public void SetDepartmentName(string departmentName)
        {
            if (string.IsNullOrWhiteSpace(departmentName))
                throw new ArgumentException("Department name cannot be null or empty.", nameof(departmentName));
            DepartmentName = departmentName;
        }
        public void SetDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description cannot be null or empty.", nameof(description));
            Description = description;
        }
        public void SetManagerId(Guid managerId)
        {
            if (managerId == Guid.Empty)
                throw new ArgumentException("Manager ID cannot be empty.", nameof(managerId));
            ManagerId = managerId;
        }
    }
}
