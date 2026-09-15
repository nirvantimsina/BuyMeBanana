using MediatR;
using Nudge.Domain.Models;
using Nudge.Shared.Wrappers;

namespace Nudge.Application.Features.Reports.Queries.GetUserReport
{
    public class GetUserReportQuery : IRequest<ApiResponse>
    {
        public int UserId { get; set; }
    }
}





