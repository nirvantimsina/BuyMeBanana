using MediatR;
using BMAB.Application.Interfaces;
using BMAB.Application.Models.Auth.Response;
using BMAB.Domain.Models;
using System.Data;
using System.Data.Common;
using BMAB.Shared.Wrappers;

namespace BMAB.Application.Features.Auth.Queries.GetMenuList
{
    public class GetMenuListQueryHandler : IRequestHandler<GetMenuListQuery, ApiResponse>
    {
        private readonly IGenericRepository _repo;

        public GetMenuListQueryHandler(IGenericRepository repo)
        {
            _repo = repo;
        }

        public async Task<ApiResponse> Handle(GetMenuListQuery request, CancellationToken cancellationToken)
        {
            var MenuListParams = new {p_role = request.RoleId };
            var result = await _repo.QueryAsync<MenuListResponseModel>(
                "SELECT * FROM permission.get_menulist_by_role(@p_role);",
                MenuListParams,
                commandType: CommandType.Text);

            return result != null ? ApiResponse.Ok(result) : ApiResponse.Fail("No roles assigned to the user!");
        }
    }
}
