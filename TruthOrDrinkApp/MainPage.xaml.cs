using Microsoft.Maui.Controls;
using SQLiteBrowser;

namespace TruthOrDrinkApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OpenDatabaseBrowser(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DatabaseBrowserPage(Path.Combine(FileSystem.AppDataDirectory, "TruthOrDrink.db")));
        }

        // Logout-knop eventhandler
        private async void OnLogoutButtonClicked(object sender, EventArgs e)
        {
            bool confirmLogout = await DisplayAlert("Bevestigen", "Weet je zeker dat je wilt uitloggen?", "Ja", "Nee");
            if (confirmLogout)
            {
                // Terug naar de loginpagina (vervang LoginPage door je eigen loginpagina)
                Application.Current.MainPage = new LoginPage();
            }
        }

        // Nieuw spel-knop eventhandler
        private async void OnNewGameButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewGamePage());
        }

        // Vragen aanmaken-knop eventhandler
        private async void OnCreateQuestionsButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateQuestionsPage());
        }
    }
}
