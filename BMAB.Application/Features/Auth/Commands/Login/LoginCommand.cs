using MediatR;
using BMAB.Domain.Models;

namespace BMAB.Application.Features.Auth.Commands.Login
{
    public class LoginCommand : IRequest<ApiResponse>
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}





