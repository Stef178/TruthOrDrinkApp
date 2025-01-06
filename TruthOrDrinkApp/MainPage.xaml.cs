using Microsoft.Maui.Controls;
using TruthOrDrinkApp.Data;
using TruthOrDrinkApp.Models;
using System.IO;
using SQLiteBrowser;

namespace TruthOrDrinkApp
{
    public partial class MainPage : ContentPage
    {
        private readonly Constants _database;
        private readonly User _currentUser;

        public MainPage(Constants database, User currentUser) // Constructor aangepast
        {
            InitializeComponent();
            _database = database;
            _currentUser = currentUser;

            // Stel de welkomsttekst in
            WelcomeLabel.Text = $"Welkom, {_currentUser.Name}!";
        }

        private async void OnLogoutButtonClicked(object sender, EventArgs e)
        {
            bool confirmLogout = await DisplayAlert("Bevestigen", "Weet je zeker dat je wilt uitloggen?", "Ja", "Nee");
            if (confirmLogout)
            {
                Application.Current.MainPage = new LoginPage(_database);
            }
        }

        private async void OnNewGameButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewGamePage());
        }

        private async void OnCreateQuestionsButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateQuestionsPage());
        }

        private async void OpenDatabaseBrowser(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DatabaseBrowserPage(Path.Combine(FileSystem.AppDataDirectory, "TruthOrDrink.db")));
        }
    }
}
