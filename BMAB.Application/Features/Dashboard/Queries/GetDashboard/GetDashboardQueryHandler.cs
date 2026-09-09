using MediatR;
using BMAB.Application.Interfaces;
using BMAB.Application.Models.Dashboard.ResponseModel;
using BMAB.Domain.Models;
using System.Data;

namespace BMAB.Application.Features.Dashboard.Queries.GetDashboard
{
    public class GetDashboardQueryHandler : IRequestHandler<GetDashboardQuery, ApiResponse>
    {
        private readonly IGenericRepository _repo;

        public GetDashboardQueryHandler(IGenericRepository repo)
        {
            _repo = repo;
        }

        public async Task<ApiResponse> Handle(GetDashboardQuery request, CancellationToken cancellationToken)
        {
            var paramsObj = new { p_flag = "A", p_userid = request.UserId };
            var result = await _repo.QueryFirstOrDefaultAsync<DashboardResponseModel>(
                "SELECT * FROM public.fn_dashboard(@p_flag, @p_userid);",
                paramsObj,
                commandType: CommandType.Text);

            return result != null ? ApiResponse.Ok(result) : ApiResponse.Fail("Dashboard data not found");
        }
    }
}





