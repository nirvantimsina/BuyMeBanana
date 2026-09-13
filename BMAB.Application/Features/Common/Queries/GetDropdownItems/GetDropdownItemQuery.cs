using ErrorOr;
using MediatR;
using BMAB.Shared.Models;

namespace BMAB.Application.Features.Common.Queries.GetDropdownItems;

public record GetDropdownItemQuery(string Flag) : IRequest<ErrorOr<List<DropdownListModel>>>;
