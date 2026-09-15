using Nudge.UI.Shared.Security;
using Nudge.UI.Shared.Infrastructure;
using Nudge.UI.Features.Dashboard.Models.ResponseModel;

namespace Nudge.UI.Features.Dashboard.Managers.Interface
{
    public interface IDashboardManager
    {
        Task<ApiResponse<DashboardResponseModel>> DashboardDataAsync();
    }
}







