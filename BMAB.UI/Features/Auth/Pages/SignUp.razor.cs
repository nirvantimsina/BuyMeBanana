using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;
using BMAB.UI.Features.Auth.Managers.Interface;
using BMAB.UI.Features.Auth.Models.RequestModel;

namespace BMAB.UI.Features.Auth.Pages
{
    [AllowAnonymous]
    public partial class SignUp(
        NavigationManager Navigation,
        IAuthManager AuthManager,
        ISnackbar Snackbar) : ComponentBase
    {
        private bool isPasswordVisible;
        private InputType passwordInputKind => isPasswordVisible ? InputType.Text : InputType.Password;
        private string passwordIcon => isPasswordVisible ? Icons.Material.Filled.Visibility :
            Icons.Material.Filled.VisibilityOff;

        private void TogglePasswordVisibility() => isPasswordVisible = !isPasswordVisible;
        private bool isPasswordVisible2;
        private InputType passwordInputKind2 => isPasswordVisible2 ? InputType.Text : InputType.Password;
        private string passwordIcon2 => isPasswordVisible2 ? Icons.Material.Filled.Visibility : Icons.Material.Filled.VisibilityOff;
        private void TogglePasswordVisibility2() => isPasswordVisible2 = !isPasswordVisible2;
        [CascadingParameter] protected Task<AuthenticationState> AuthStateTask { get; set; } = default!;
        protected SignUpRequest request = new();
        protected string? error;
        protected bool IsLoading = false;
        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthStateTask;

            if (authState.User.Identity is { IsAuthenticated: true })
            {
                Navigation.NavigateTo("dashboard");
            }
        }
        protected async Task HandleSignUp()
        {
            error = null;
            IsLoading = true;

            try
            {
                var result = await AuthManager.SignUpAsync(request);

                if (result == null || !result.Success)
                {
                    error = result?.Message ?? "Signup Failed!";

                    Snackbar.Add(error, Severity.Error);
                    return;
                }

                Snackbar.Add("Account created successfully!", Severity.Success);
                Navigation.NavigateTo("/login");
            }
            catch
            {
                error = "Something went wrong";
                Snackbar.Add(error, Severity.Error);
            }
            finally
            {
                IsLoading = false;
            }
        }
        protected async Task HandleKeyUp(KeyboardEventArgs e)
        {
            if (e.Key == "Enter")
            {
                await HandleSignUp();
            }
        }
    }
}

