namespace SalaryAdvanceSource.DTOs
{
    public class PagedRequestDto
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? SearchTerm { get; set; }
        public string? SearchField { get; set; }
        public string? SortField { get; set; }
        public bool SortDescending { get; set; } = false;
    }
}
