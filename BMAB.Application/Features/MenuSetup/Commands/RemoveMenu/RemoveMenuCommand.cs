using MediatR;
using BMAB.Domain.Models;

namespace BMAB.Application.Features.MenuSetup.Commands.RemoveMenu
{
    public class RemoveMenuCommand : IRequest<ApiResponse>
    {
        public int MenuId { get; set; }
    }
}



