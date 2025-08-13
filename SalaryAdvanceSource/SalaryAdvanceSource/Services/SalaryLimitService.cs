using SalaryAdvanceSource.Data;
using SalaryAdvanceSource.DTOs;
using SalaryAdvanceSource.Models;

namespace SalaryAdvanceSource.Services
{
    public class SalaryLimitService : ISalaryLimitService
    {
        private readonly Idpsalary _context;
        public SalaryLimitService(Idpsalary context) 
        {
            _context = context;
        }
        public async Task CreateLimitAsync(CreateLimitDto createLimitDto)
        {
            var limit = new SalaryLimits(
                createLimitDto.LimitName,
                createLimitDto.Description,
                createLimitDto.CreatedUserId,
                DateTime.SpecifyKind(createLimitDto.StartTime, DateTimeKind.Utc),
                DateTime.SpecifyKind(createLimitDto.EndTime, DateTimeKind.Utc),
                createLimitDto.ObjectType,
                createLimitDto.ObjectId,
                createLimitDto.IsGroup
            );

            _context.SalaryLimits.Add(limit);
            await _context.SaveChangesAsync();

            foreach (var detail in createLimitDto.LimitDetails)
            {
                var limitDetail = new SalaryLimitDetails(
                    limit.LimitId,
                    detail.Priority,
                    detail.TimeLimit,
                    detail.AmountLimitType,
                    detail.AmountLimitValue
                );
                _context.SalaryLimitDetails.Add(limitDetail);
            }

            await _context.SaveChangesAsync();
        }

    }
}
