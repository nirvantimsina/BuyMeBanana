using MediatR;
using Nudge.Domain.Models;
using Nudge.Shared.Wrappers;

namespace Nudge.Application.Features.Auth.Commands.Login
{
    public class LoginCommand : IRequest<ApiResponse>
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
