using Nudge.UI.Shared.Security;
using Nudge.UI.Shared.Infrastructure;
using Nudge.UI.Features.Reports.Models.RequestModel;
using Nudge.UI.Features.Reports.Models.ResponseModel;

namespace Nudge.UI.Features.Reports.Managers.Interface
{
    public interface IUserReportManager
    {
        Task<ApiResponse<List<UserReportResponseModel>>> UserReportDataAsync(UserReportRequestModel request);
    }
}








