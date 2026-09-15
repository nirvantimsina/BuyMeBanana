using ErrorOr;
using MediatR;
using Nudge.Shared.Models;

namespace Nudge.Application.Features.Common.Queries.GetDropdownItems;

public record GetDropdownItemQuery(string Flag) : IRequest<ErrorOr<List<DropdownListModel>>>;
