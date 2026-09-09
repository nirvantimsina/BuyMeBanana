using MediatR;
using BMAB.Application.Helpers;
using BMAB.Application.Interfaces;
using BMAB.Domain.Models;
using System.Data;
using System.Data.Common;
using BMAB.Application.Features.CreatorSetup.Commands.CreatorDetails;
using BMAB.Application.Features.KYC.Commands.UserKYCDetails;

namespace BMAB.Application.Features.CreatorSetup.Commands.CreatorDetails;

public class CreatorDetailsCommandHandler : IRequestHandler<CreatorDetailsCommand, ApiResponse>
{
    private readonly IGenericRepository _repo;

    public CreatorDetailsCommandHandler(IGenericRepository repo)
    {
        _repo = repo;
    }

    public async Task<ApiResponse> Handle(CreatorDetailsCommand request, CancellationToken cancellationToken)
    {
        var Params = new
        {
            p_userid = request.UserID,
            p_platform = request.Platform,
            p_username = request.UserName,
            p_link = request.Link
        };

        await _repo.ExecuteAsync(
            "select creator.insert_creator_details(@p_userid, p_platform, p_username, p_link)",
            Params,
            commandType: CommandType.Text
        );

        return ApiResponse.Ok();
    }
}