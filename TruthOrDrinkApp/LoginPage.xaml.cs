using Microsoft.Maui.Controls;

namespace TruthOrDrinkApp
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            if (UsernameEntry.Text == "admin" && PasswordEntry.Text == "1234")
            {
                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                ErrorLabel.Text = "Invalid login";
                ErrorLabel.IsVisible = true;
            }
        }
    }
}
