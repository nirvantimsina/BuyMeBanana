using MediatR;
using BMAB.Application.Interfaces;
using BMAB.Domain.Models;
using System.Data;
using BMAB.Shared.Wrappers;
using BMAB.Application.Common.Extensions;
using ErrorOr;

namespace BMAB.Application.Features.MenuSetup.Commands.RemoveMenu
{
    public class RemoveMenuCommandHandler : IRequestHandler<RemoveMenuCommand, ErrorOr<StatusResponse>>
    {
        private readonly IGenericRepository _repo;

        public RemoveMenuCommandHandler(IGenericRepository repo)
        {
            _repo = repo;
        }

        public async Task<ErrorOr<StatusResponse>> Handle(RemoveMenuCommand request, CancellationToken cancellationToken)
        {
            var Params = new 
            {
                p_flag = "B",
                p_menuid = request.MenuId
            };

            var result = await _repo.QueryFirstOrDefaultAsync<StatusResponse>("SELECT * FROM sp_menusetup(@p_flag, @p_menuid)", Params, CommandType.Text);

            return result.ToDbResult();
        }
    }
}



