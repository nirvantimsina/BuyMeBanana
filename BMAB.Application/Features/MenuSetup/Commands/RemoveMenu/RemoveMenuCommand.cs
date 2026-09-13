using ErrorOr;
using MediatR;
using BMAB.Domain.Models;

namespace BMAB.Application.Features.MenuSetup.Commands.RemoveMenu
{
    public class RemoveMenuCommand : IRequest<ErrorOr<StatusResponse>>
    {
        public int MenuId { get; set; }
    }
}
