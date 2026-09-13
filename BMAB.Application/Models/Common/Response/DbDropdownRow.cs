using BMAB.Domain.Models;

namespace BMAB.Application.Models.Common.Response
{
    public class DbDropdownRow : StatusResponse
    {
        public string? Text { get; set; } = string.Empty;
        public string? Value { get; set; } = string.Empty;
    }
}
