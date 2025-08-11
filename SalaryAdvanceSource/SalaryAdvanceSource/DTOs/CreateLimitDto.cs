using SalaryAdvanceSource.Models;
using System.ComponentModel.DataAnnotations;

namespace SalaryAdvanceSource.DTOs
{
    public class CreateLimitDto
    {
        [Required]
        [StringLength(100)]
        public string LimitName { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public Guid CreatedUserId { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required] 
        public DateTime EndTime { get; set; }

        [Required] 
        public ObjectType ObjectType { get; set; } = ObjectType.EMP;

        [Required]
        public Guid ObjectId { get; set; }

        [Required]
        public bool IsGroup { get; set; } = false;

        public List<CreateLimitDetailDto> LimitDetails { get; set; } = new();
    }
}
