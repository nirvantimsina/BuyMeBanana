using BMAB.UI.Shared.Security;
using BMAB.UI.Shared.Infrastructure;

namespace BMAB.UI.Features.Auth;

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







