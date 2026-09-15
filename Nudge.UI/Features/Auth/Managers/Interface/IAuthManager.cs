using Nudge.UI.Shared.Security;
using Nudge.UI.Shared.Infrastructure;
using Nudge.UI.Features.Auth.Models.RequestModel;
using Nudge.UI.Features.Auth.Models.ResponseModel;

namespace Nudge.UI.Features.Auth.Managers.Interface;

public interface IAuthManager
{
    Task<ApiResponse<LoginResponse>> LoginAsync(LoginRequest request);
    Task<ApiResponse> SignUpAsync(SignUpRequest request);
}







