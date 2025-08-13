using System.ComponentModel.DataAnnotations;

namespace SalaryAdvanceSource.Models
{
    public enum PriorityType
    {
        OneTime = 0,
        Daily = 1
    }
    public enum AmountLimitType
    {
        FIX = 0,
        PER = 1,
        EXP = 2
    }
    public class SalaryLimitDetails
    {
        // ====== Properties ======
        [Key]
        public Guid LimitDetailId { get; private set; } = Guid.NewGuid();
        public Guid LimitId { get; private set; }
        public PriorityType Priority { get; private set; }
        public int TimeLimit { get; private set; } = 0;
        public AmountLimitType AmountLimitType { get; private set; }
        public decimal AmountLimitValue { get; private set; } = 0;

        public SalaryLimits SalaryLimits { get; private set; } = null!;

        // ====== Constructors ======
        private SalaryLimitDetails() { }
        public SalaryLimitDetails(Guid limitId, PriorityType priority, int timeLimit, AmountLimitType amountLimitType, decimal amountLimitValue)
        {
            LimitId = limitId;
            Priority = priority;
            TimeLimit = timeLimit;
            AmountLimitType = amountLimitType;
            AmountLimitValue = amountLimitValue;
        }
        public void Update(PriorityType priority, int timeLimit, AmountLimitType amountLimitType, decimal amountLimitValue)
        {
            Priority = priority;
            TimeLimit = timeLimit;
            AmountLimitType = amountLimitType;
            AmountLimitValue = amountLimitValue;
        }
    }
}
