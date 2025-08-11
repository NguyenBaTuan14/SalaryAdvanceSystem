using SalaryAdvanceSource.Models;
using System.ComponentModel.DataAnnotations;

namespace SalaryAdvanceSource.DTOs
{
    public class CreateLimitDetailDto
    {
        [Required]
        public Guid LimitId { get; set; }

        [Required]
        public PriorityType Priority { get; set; }

        public int TimeLimit { get; set; }

        [Required]
        public AmountLimitType AmountLimitType { get; set; }

        [Required]
        public decimal AmountLimitValue { get; set; }
    }
}
