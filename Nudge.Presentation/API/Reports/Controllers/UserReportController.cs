using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nudge.Application.Features.Reports.Queries.GetUserReport;

namespace Nudge.Presentation.Controllers
{
    public class UserReportController(IMediator mediator) : ApiBaseController
    {
        [HttpPost("UserReportData")]
        public async Task<IActionResult> GetUserReportData([FromBody] GetUserReportQuery query)
        {
            var result = await mediator.Send(query);
            return HandleResponse(result);
        }
    }
}



