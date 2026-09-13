using MediatR;
using BMAB.Domain.Models;
using BMAB.Shared.Wrappers;

namespace BMAB.Application.Features.Auth.Queries.GetMenuList
{
    public class GetMenuListQuery : IRequest<ApiResponse>
    {
        public int RoleId { get; set; }
    }
}





