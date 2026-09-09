using MediatR;
using BMAB.Domain.Models;

namespace BMAB.Application.Features.Auth.Queries.GetMenuList
{
    public class GetMenuListQuery : IRequest<ApiResponse>
    {
        public int RoleId { get; set; }
    }
}





