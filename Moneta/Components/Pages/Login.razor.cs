
using DataModel.Model;

namespace Moneta.Components.Pages
{
    public partial class Login
    {
        private string? errorMessege;
        public UserModel users { get; set; } = new();

        private async void HandelLogin() {
            if (await UserService.login(users))
            {
                Nav.NavigateTo("/home");
            }
            else {
                errorMessege = "Invalid username or password";
            }
        }
    }
}