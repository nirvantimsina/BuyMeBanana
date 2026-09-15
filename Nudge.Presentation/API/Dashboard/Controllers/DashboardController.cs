using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nudge.Application.Features.Dashboard.Queries.GetDashboard;
using ErrorOr;
using Nudge.Application.Models.Dashboard.ResponseModel;
using Nudge.Shared.Wrappers;

namespace Nudge.Presentation.Controllers
{
    [ApiController]
    public class DashboardController(IMediator mediator) : ApiBaseController
    {
        [HttpGet("DashboardData")]
        public async Task<IActionResult> GetDashboardData([FromQuery] GetDashboardQuery query)
        {
            query.UserId = CurrentUserId;
            ErrorOr<DashboardResponseModel> result = await mediator.Send(query);

            return result.Match<IActionResult>(data => Ok(ApiResponse.Ok(data)),
                errors => BadRequest(ApiResponse.Fail(errors.First().Description, errors.First().Code)));
        }
    }
}



