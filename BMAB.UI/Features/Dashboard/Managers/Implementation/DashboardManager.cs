using BMAB.UI.Features.Auth;
using BMAB.UI.Shared.Infrastructure;
using BMAB.UI.Features.Dashboard.Managers.Interface;
using BMAB.UI.Features.Dashboard.Managers.Route;
using BMAB.UI.Features.Dashboard.Models.ResponseModel;

namespace BMAB.UI.Features.Dashboard.Managers.Implementation;

public class DashboardManager(IHttpClientFactory factory, AuthSessionManager sessionManager, ILogger<DashboardManager> logger)
    : BaseManager(sessionManager, logger), IDashboardManager
{
    public async Task<ApiResponse<DashboardResponseModel>> DashboardDataAsync()
    {
        var http = factory.CreateClient("API");
        await SetAuthHeaderAsync(http);

        var response = await http.GetAsync(DashboardRoute.DashboardData);
        return await HandleResponse<DashboardResponseModel>(response);
    }
}
