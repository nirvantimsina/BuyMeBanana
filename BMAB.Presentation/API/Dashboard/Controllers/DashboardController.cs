using MediatR;
using Microsoft.AspNetCore.Mvc;
using BMAB.Application.Features.Dashboard.Queries.GetDashboard;

namespace BMAB.Presentation.Controllers
{
    [ApiController]
    public class DashboardController(IMediator mediator) : ApiBaseController
    {
        [HttpGet("DashboardData")]
        public async Task<IActionResult> GetDashboardData([FromQuery] GetDashboardQuery query)
        {
            query.UserId = CurrentUserId;
            var result = await mediator.Send(query);
            return HandleResponse(result);
        }
    }
}



