namespace Moneta.Components.Pages
{
    public partial class Logout
    {
        protected override void OnInitialized()
        {
            Nav.NavigateTo("/login");
        }
    }
}