using MediatR;
using Microsoft.AspNetCore.Mvc;
using BMAB.Application.Features.Common.Queries.GetDropdownItems;
using BMAB.Shared.Wrappers;

namespace BMAB.Presentation.Controllers;

public class DropdownController(IMediator mediator) : ApiBaseController
{
    [HttpGet("{flag}")]
    public async Task<IActionResult> GetByFlag(string flag)
    {
        var query = new GetDropdownItemQuery(flag);
        var result = await mediator.Send(query);

        return result.Match<IActionResult>(
            data => Ok(ApiResponse<List<Shared.Models.DropdownListModel>>.Ok(data)),
            errors => BadRequest(ApiResponse.Fail(errors.First().Description, errors.First().Code))
        );
    }
}
