using BMAB.UI.Shared.Security;
using BMAB.UI.Shared.Infrastructure;
using BMAB.UI.Features.Dashboard.Models.ResponseModel;

namespace BMAB.UI.Features.Dashboard.Managers.Interface
{
    public interface IDashboardManager
    {
        Task<ApiResponse<DashboardResponseModel>> DashboardDataAsync();
    }
}







