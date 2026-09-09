using MediatR;
using BMAB.Application.Interfaces;
using BMAB.Application.Models.Reports.ResponseModel;
using BMAB.Domain.Models;
using System.Data;

namespace BMAB.Application.Features.Reports.Queries.GetUserReport
{
    public class GetUserReportQueryHandler : IRequestHandler<GetUserReportQuery, ApiResponse>
    {
        private readonly IGenericRepository _repo;

        public GetUserReportQueryHandler(IGenericRepository repo)
        {
            _repo = repo;
        }

        public async Task<ApiResponse> Handle(GetUserReportQuery request, CancellationToken cancellationToken)
        {
            var paramobj = new { p_flag = "A", p_userid = request.UserId };
            var result = await _repo.QueryAsync<UserReportResponseModel>(
                "SELECT * FROM \"user\".fn_userreport(@p_flag, @p_userid);",
                paramobj,
                commandType: CommandType.Text);

            return result != null ? ApiResponse.Ok(result) : ApiResponse.Fail("Data not found");
        }
    }
}



