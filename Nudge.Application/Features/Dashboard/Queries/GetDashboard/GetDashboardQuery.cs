using ErrorOr;
using MediatR;
using Nudge.Application.Models.Dashboard.ResponseModel;

namespace Nudge.Application.Features.Dashboard.Queries.GetDashboard
{
    public class GetDashboardQuery : IRequest<ErrorOr<DashboardResponseModel>>
    {
        public int UserId { get; set; }
    }
}
