using BMAB.UI.Shared.Security;
using BMAB.UI.Features.Auth;
using BMAB.UI.Shared.Infrastructure;
using BMAB.UI.Shared.Infrastructure;
using BMAB.UI.Features.Reports.Managers.Interface;
using BMAB.UI.Features.Reports.Managers.Route;
using BMAB.UI.Features.Reports.Models.RequestModel;
using BMAB.UI.Features.Reports.Models.ResponseModel;

namespace BMAB.UI.Features.Reports.Managers.Implementation
{
    public class UserReportManager(IHttpClientFactory factory, AuthSessionManager sessionManager) : BaseManager(sessionManager), IUserReportManager
    {
        public async Task<ApiResponse<List<UserReportResponseModel>>> UserReportDataAsync(UserReportRequestModel request)
        {
            var http = factory.CreateClient("API");
            await SetAuthHeaderAsync(http);

            var response = await http.PostAsJsonAsync(UserReportRoute.UserReportData, request);
            return await HandleResponse<List<UserReportResponseModel>>(response);
        }
    }
}






