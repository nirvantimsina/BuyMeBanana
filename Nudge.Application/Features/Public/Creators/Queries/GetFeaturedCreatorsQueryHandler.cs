using System.Data;
using ErrorOr;
using MediatR;
using Nudge.Application.Common.Extensions;
using Nudge.Application.Interfaces;
using Nudge.Application.Models.Public.Creators.ResponseModel;

namespace Nudge.Application.Features.Public.Creators.Queries.GetFeaturedCreators;
public record GetFeaturedCreatorsQuery : IRequest<ErrorOr<List<FeaturedCreatorsResponseModel>>>;

public class GetFeaturedCreatorsQueryHandler : IRequestHandler<GetFeaturedCreatorsQuery, ErrorOr<List<FeaturedCreatorsResponseModel>>>
{
    private readonly IGenericRepository _repo;

    public GetFeaturedCreatorsQueryHandler(IGenericRepository repo)
    {
        _repo = repo;
    }

    public async Task<ErrorOr<List<FeaturedCreatorsResponseModel>>> Handle(GetFeaturedCreatorsQuery request, CancellationToken cancellationToken)
    {
        var result = await _repo.QueryAsync<FeaturedCreatorsResponseModel>(
            "select * from creators.public_featured_creators();",
            new {},
            commandType: CommandType.Text
        );

        return result.ToDbResultList();
    }
}
