using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nudge.Application.Features.Public.Creators.Queries.GetFeaturedCreators;
using Nudge.Application.Models.Public.Creators.ResponseModel;
using Nudge.Shared.Wrappers;

namespace Nudge.Presentation.Controllers.PublicAPI;

[ApiController]
public class PublicAPIController(IMediator mediator, ILogger<PublicAPIController> logger) : ApiBaseController
{
    [HttpGet("FeaturedCreators")]
    [AllowAnonymous]
    public async Task<IActionResult> GetFeaturedCreatorsAsync()
    {
        ErrorOr<List<FeaturedCreatorsResponseModel>> result = await mediator.Send(new GetFeaturedCreatorsQuery());        
        
        return result.Match<IActionResult>(
            data => Ok(ApiResponse<List<FeaturedCreatorsResponseModel>>.Ok(data)),
            errors => BadRequest(ApiResponse.Fail(errors.First().Description, errors.First().Code))
        );
    }
}