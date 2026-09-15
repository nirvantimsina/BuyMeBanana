using Nudge.Domain.Models;

namespace Nudge.Application.Models.Public.Creators.ResponseModel;

public class FeaturedCreatorsResponseModel : StatusResponse
{
    public string? CreatorID { get; set; }
    public string? Slug { get; set; }
    public string? Category { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int NudgeCount { get; set; }
    public string? Avatar { get; set; }
    public string? TierName { get; set; }
}