using ErrorOr;
using MediatR;
using BMAB.Application.Interfaces;
using BMAB.Application.Models.Dashboard.ResponseModel;
using BMAB.Application.Common.Extensions;
using System.Data;

namespace BMAB.Application.Features.Dashboard.Queries.GetDashboard
{
    public class GetDashboardQueryHandler : IRequestHandler<GetDashboardQuery, ErrorOr<DashboardResponseModel>>
    {
        private readonly IGenericRepository _repo;

        public GetDashboardQueryHandler(IGenericRepository repo)
        {
            _repo = repo;
        }

        public async Task<ErrorOr<DashboardResponseModel>> Handle(GetDashboardQuery request, CancellationToken cancellationToken)
        {
            var result = await _repo.QueryFirstOrDefaultAsync<DashboardResponseModel>(
                "SELECT * FROM public.fn_dashboard(@p_userid);",
                new { p_userid = request.UserId },
                commandType: CommandType.Text);

            return result.ToDbResult();
        }
    }
}


