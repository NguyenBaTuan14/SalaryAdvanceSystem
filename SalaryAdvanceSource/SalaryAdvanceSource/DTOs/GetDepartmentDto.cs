namespace SalaryAdvanceSource.DTOs
{
    public class GetDepartmentDto
    {
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid ManagerId { get; set; }
    }
}
