using System.ComponentModel.DataAnnotations;

namespace SalaryAdvanceSource.Models
{
    public enum ObjectType
    {
        EMP = 0,
        DEP = 1
    }
    public class SalaryLimits
    {
        // ====== Properties ======
        [Key]
        public Guid LimitId { get; private set; } = Guid.NewGuid();
        public string LimitName { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public Guid CreatedUserId { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public Guid ModifiedUserId { get; private set; }
        public DateTime ModifiedAt { get; private set; } = DateTime.UtcNow;
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public ObjectType ObjectType { get; private set; }
        public Guid ObjectId { get; private set; }
        public bool IsGroup { get; private set; } = false;

        public ICollection<SalaryLimitDetails> SalaryLimitDetails { get; private set; } = new List<SalaryLimitDetails>();

        // ====== Constructors ======
        private SalaryLimits() { }
        public SalaryLimits(string limitName, string description, Guid createdUserId, DateTime startTime, DateTime endTime, ObjectType objectType, Guid objectId, bool isGroup = false)
        {
            SetLimitName(limitName);
            SetDescription(description);
            CreatedUserId = createdUserId;
            StartTime = startTime;
            EndTime = endTime;
            ObjectType = objectType;
            ObjectId = objectId;
            IsGroup = isGroup;
        }
        // ====== Methods ======
        public void SetLimitName(string limitName)
        {
            if (string.IsNullOrWhiteSpace(limitName))
                throw new ArgumentException("Limit name cannot be empty.", nameof(limitName));
            LimitName = limitName;
        }
        public void SetDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description cannot be empty.", nameof(description));
            Description = description;
        }
        public void Update(string limitName, string description, Guid modifiedUserId, DateTime startTime, DateTime endTime, ObjectType objectType, Guid objectId, bool isGroup)
        {
            SetLimitName(limitName);
            SetDescription(description);
            ModifiedUserId = modifiedUserId;
            ModifiedAt = DateTime.UtcNow;
            StartTime = startTime;
            EndTime = endTime;
            ObjectType = objectType;
            ObjectId = objectId;
            IsGroup = isGroup;
        }

    }
}
