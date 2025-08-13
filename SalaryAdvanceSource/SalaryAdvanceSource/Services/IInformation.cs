using SalaryAdvanceSource.DTOs;

namespace SalaryAdvanceSource.Services
{
    public interface IInformation
    {
        Task<List<GetInfo>> GetListInfo(string groupCode);
    }
}
