using MediatR;
using BMAB.Domain.Models;
using BMAB.Shared.Wrappers;

namespace BMAB.Application.Features.KYC.Commands.UserKYCDetails
{
    public class KycDetailsCommand : IRequest<ApiResponse>
    {
        public int UserId { get; set; }
        public string? LegalName { get; set; }
        public string? CitizenshipNo { get; set; }
        public string? CitizenshipImage { get; set; }
        public string? DOB { get; set; }
        public string? Province { get; set; }
        public string? District { get; set; }
        public string? VDCMCP { get; set; }
        public string? Ward { get; set; } 
    }
}
