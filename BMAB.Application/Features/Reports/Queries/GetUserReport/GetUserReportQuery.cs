using MediatR;
using BMAB.Domain.Models;
using BMAB.Shared.Wrappers;

namespace BMAB.Application.Features.Reports.Queries.GetUserReport
{
    public class GetUserReportQuery : IRequest<ApiResponse>
    {
        public int UserId { get; set; }
    }
}





