using MediatR;
using BMAB.Domain.Models;

namespace BMAB.Application.Features.Dashboard.Queries.GetDashboard
{
    public class GetDashboardQuery : IRequest<ApiResponse>
    {
        public int UserId { get; set; }
    }
}





