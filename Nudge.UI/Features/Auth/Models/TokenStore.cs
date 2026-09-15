using Nudge.UI.Shared.Security;
using Nudge.UI.Shared.Infrastructure;

namespace Nudge.UI.Features.Auth;

public class TokenStore
{
    private string? _token;

    public string? Token
    {
        get => _token;
        set => _token = value;
    }
    public List<MenuListModel> MenuList { get; set; } = new();
}







