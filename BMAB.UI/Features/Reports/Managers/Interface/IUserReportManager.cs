using BMAB.UI.Shared.Security;
using BMAB.UI.Shared.Infrastructure;
using BMAB.UI.Features.Reports.Models.RequestModel;
using BMAB.UI.Features.Reports.Models.ResponseModel;

namespace BMAB.UI.Features.Reports.Managers.Interface
{
    public interface IUserReportManager
    {
        Task<ApiResponse<List<UserReportResponseModel>>> UserReportDataAsync(UserReportRequestModel request);
    }
}








