using ErrorOr;
using MediatR;
using Nudge.Domain.Models;

namespace Nudge.Application.Features.MenuSetup.Commands.RemoveMenu
{
    public class RemoveMenuCommand : IRequest<ErrorOr<StatusResponse>>
    {
        public int MenuId { get; set; }
    }
}
