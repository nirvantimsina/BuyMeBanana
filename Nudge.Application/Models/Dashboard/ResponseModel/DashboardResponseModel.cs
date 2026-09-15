using Nudge.Domain.Models;

namespace Nudge.Application.Models.Dashboard.ResponseModel;

public class DashboardResponseModel : StatusResponse
{
    public string? Name { get; set; }
    public string? UserRole { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
}
