using MediatR;
using Microsoft.AspNetCore.Mvc;
using BMAB.Application.Features.Dashboard.Queries.GetDashboard;
using BMAB.Application.Features.KYC.Commands.UserKYCDetails;
using Microsoft.Extensions.Logging;

namespace BMAB.Presentation.Controllers.KYC
{
    [ApiController]
    public class KYCController(IMediator mediator, ILogger<KYCController> logger) : ApiBaseController
    {
        [HttpGet("InsertKycDetails")]
        public async Task<IActionResult> InsertKycDetails([FromBody] KycDetailsCommand command)
        {
            command.UserId = CurrentUserId;
            logger.LogInformation("KYC Details Insert for user: {UserName}", command.UserId);
            var result = await mediator.Send(command);
            return HandleResponse(result);
        }
    }
}