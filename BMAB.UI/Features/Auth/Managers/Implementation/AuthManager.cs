using BMAB.UI.Shared.Infrastructure;
using BMAB.UI.Features.Auth.Managers.Interface;
using BMAB.UI.Features.Auth.Managers.Route;
using BMAB.UI.Features.Auth.Models.RequestModel;
using BMAB.UI.Features.Auth.Models.ResponseModel;

namespace BMAB.UI.Features.Auth.Managers.Implementation;

public class AuthManager(IHttpClientFactory factory, AuthSessionManager sessionManager, ILogger<AuthManager> logger)
    : BaseManager(sessionManager, logger), IAuthManager
{
    public async Task<ApiResponse<LoginResponse>> LoginAsync(LoginRequest request)
    {
        var http = factory.CreateClient("API");
        var response = await http.PostAsJsonAsync(AuthRoute.Login, request);
        return await HandleResponse<LoginResponse>(response);
    }

    public async Task<ApiResponse> SignUpAsync(SignUpRequest request)
    {
        var http = factory.CreateClient("API");

        var response = await http.PostAsJsonAsync(AuthRoute.SignUp, request);
        return await HandleResponse(response);
    }
}