using ErrorOr;
using MediatR;
using BMAB.Application.Models.Dashboard.ResponseModel;

namespace BMAB.Application.Features.Dashboard.Queries.GetDashboard
{
    public class GetDashboardQuery : IRequest<ErrorOr<DashboardResponseModel>>
    {
        public int UserId { get; set; }
    }
}
