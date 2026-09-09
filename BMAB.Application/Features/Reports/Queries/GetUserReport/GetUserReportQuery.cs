using MediatR;
using BMAB.Domain.Models;

namespace BMAB.Application.Features.Reports.Queries.GetUserReport
{
    public class GetUserReportQuery : IRequest<ApiResponse>
    {
        public int UserId { get; set; }
    }
}





