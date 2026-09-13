using MediatR;
using BMAB.Application.Helpers;
using BMAB.Application.Interfaces;
using BMAB.Domain.Models;
using System.Data;
using BMAB.Shared.Wrappers;

namespace BMAB.Application.Features.KYC.Commands.UserKYCDetails
{
    public class KycDetailsCommandHandler : IRequestHandler<KycDetailsCommand, ApiResponse>
    {
        private readonly IGenericRepository _repo;

        public KycDetailsCommandHandler(IGenericRepository repo)
        {
            _repo = repo;
        }

        public async Task<ApiResponse> Handle(KycDetailsCommand request, CancellationToken cancellationToken)
        {
            var @params = new
            {
                p_legalname = request.LegalName,
                p_citizenshipno = request.CitizenshipNo,
                p_citizenshipimage = request.CitizenshipImage,
                p_dob = request.DOB,
                p_provoince = request.Province,
                p_district = request.District,
                p_vdcmcp = request.VDCMCP,
                p_ward = request.Ward
            };

            await _repo.ExecuteAsync(
                "select users.insertkycdetails(@p_legalname, @p_citizenshipno, @p_citizenshipimage, @p_dob, @p_provoince, @p_district, @p_vdcmcp, @p_ward)",
                @params,
                commandType: CommandType.Text);

            return ApiResponse.Ok();
        }
    }
}