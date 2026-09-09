using BMAB.UI.Shared.Security;
using BMAB.UI.Shared.Infrastructure;
using BMAB.UI.Features.Auth.Models.RequestModel;
using BMAB.UI.Features.Auth.Models.ResponseModel;

namespace BMAB.UI.Features.Auth.Managers.Interface;

public interface IAuthManager
{
    Task<ApiResponse<LoginResponse>> LoginAsync(LoginRequest request);
    Task<ApiResponse> SignUpAsync(SignUpRequest request);
}







