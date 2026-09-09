using MediatR;
using BMAB.Domain.Models;

namespace BMAB.Application.Features.CreatorSetup.Commands.CreatorDetails;

public class CreatorDetailsCommand : IRequest<ApiResponse>
{
    public int UserID { get; set; }
    public string? Platform { get; set; }
    public string? UserName { get; set; }
    public string? Link { get; set; }
}