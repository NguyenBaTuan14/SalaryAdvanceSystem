using System.ComponentModel.DataAnnotations;

namespace SalaryAdvanceSource.Models
{
    public enum RequestStatus
    {
        Pending,
        Approved,
        Rejected
    }
    public class SalaryAdvanceRequests
    {
        // ====== Properties ======
        [Key]
        public Guid RequestId { get; private set; } = Guid.NewGuid();
        public Guid EmployeeId { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime RequestDate { get; private set; } = DateTime.UtcNow;
        public string ReasonRequest { get; private set; } = string.Empty;
        public RequestStatus Status { get; private set; } = RequestStatus.Pending;
        public Guid ApprovedUserId { get; private set; }
        public DateTime ApprovedDate { get; private set; }
        public string ReasonApprove { get; private set; } = string.Empty;

        // ====== Constructors ======
        private SalaryAdvanceRequests() { }
        public SalaryAdvanceRequests(Guid employeeId, decimal amount, string reasonRequest)
        {
            EmployeeId = employeeId;
            Amount = amount;
            ReasonRequest = reasonRequest;
        }
        public void SetStatus(RequestStatus status)
        {
            Status = status;
        }
        public void SetApprovedUserId(Guid approvedUserId)
        {
            if (approvedUserId == Guid.Empty)
                throw new ArgumentException("Approved user ID cannot be empty.", nameof(approvedUserId));
            ApprovedUserId = approvedUserId;
        }
        public void SetApprovedDate(DateTime approvedDate)
        {
            if (approvedDate == default)
                throw new ArgumentException("Approved date cannot be default.", nameof(approvedDate));
            ApprovedDate = approvedDate;
        }
        public void SetReasonApprove(string reasonApprove)
        {
            if (string.IsNullOrWhiteSpace(reasonApprove))
                throw new ArgumentException("Reason for approval cannot be null or empty.", nameof(reasonApprove));
            ReasonApprove = reasonApprove;
        }
    }
}
