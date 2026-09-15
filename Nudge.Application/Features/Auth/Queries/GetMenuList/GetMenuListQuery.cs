using MediatR;
using Nudge.Domain.Models;
using Nudge.Shared.Wrappers;

namespace Nudge.Application.Features.Auth.Queries.GetMenuList
{
    public class GetMenuListQuery : IRequest<ApiResponse>
    {
        public int RoleId { get; set; }
    }
}





