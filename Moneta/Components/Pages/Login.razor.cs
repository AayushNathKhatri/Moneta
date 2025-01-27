using DataModel.Model;

namespace Moneta.Components.Pages
{
    public partial class Login
    {
        private Currency Currency { get; set; }
        private string? errorMessage;
        public UserModel users { get; set; } = new();

        private async void HandelLogin() {
            if (await UserService.login(users))
            {
                Nav.NavigateTo("/home");
            }
            else 
            {
                errorMessage = "Invalid username or password";
            }
        }
        private void CloseMe() { 
            errorMessage = string.Empty;
        }
    }
}