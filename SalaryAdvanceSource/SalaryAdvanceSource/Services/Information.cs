using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SalaryAdvanceSource.Data;
using SalaryAdvanceSource.DTOs;

namespace SalaryAdvanceSource.Services
{
    public class Information : IInformation
    {
        private readonly Idpsalary _context;
        private readonly IMapper _mapper;
        public Information(Idpsalary context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<GetInfo>> GetListInfo(string groupCode)
        {
            var query = _context.Information
                .Where(i => i.GroupCode == groupCode)
                .OrderBy(i => i.Key)
                .AsNoTracking();
            var items = await query.ToListAsync();
            return _mapper.Map<List<GetInfo>>(items);
        }
    }
}
