using MediatR;
using BMAB.Domain.Models;
using BMAB.Shared.Wrappers;

namespace BMAB.Application.Features.Auth.Commands.SignUp
{
    public class SignUpCommand : IRequest<ApiResponse>
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
    }
}
