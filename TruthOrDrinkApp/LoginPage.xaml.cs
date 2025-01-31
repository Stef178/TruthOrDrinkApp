using TruthOrDrinkApp.Data;
using TruthOrDrinkApp.Models;

namespace TruthOrDrinkApp
{
    public partial class LoginPage : ContentPage
    {
        private readonly Constants _database;

        public LoginPage(Constants database)
        {
            InitializeComponent();
            _database = database;
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var email = UsernameEntry.Text;
            var password = PasswordEntry.Text;

            var user = (await _database.GetAllAsync<User>()).FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                // Geef de ingelogde gebruiker door aan MainPage
                await Navigation.PushAsync(new MainPage(_database, user));
            }
            else
            {
                ErrorLabel.Text = "Invalid email or password";
                ErrorLabel.IsVisible = true;
            }
        }

        private async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage(_database));
        }
    }
}
