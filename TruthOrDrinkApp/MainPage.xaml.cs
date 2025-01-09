using SQLiteBrowser;
using TruthOrDrinkApp.Data;
using TruthOrDrinkApp.Models;

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
            await Navigation.PushAsync(new NewGamePage(_database));
        }

        private async void OnCreateQuestionsButtonClicked(object sender, EventArgs e)
        {

            // Navigeer naar de CreateQuestionsPage en geef de database door
            await Navigation.PushAsync(new CreateQuestionsPage(_database));
        }


        private async void OpenDatabaseBrowser(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DatabaseBrowserPage(Path.Combine(FileSystem.AppDataDirectory, "TruthOrDrink.db")));
        }

        private async void OnOpenCameraButtonClicked(object sender, EventArgs e)
        {
            try
            {
                // Open de camera en wacht tot de gebruiker een foto maakt
                var photo = await MediaPicker.CapturePhotoAsync();

                if (photo != null)
                {
                    // Opslaan of verder verwerken als nodig
                    await DisplayAlert("Foto gemaakt", "De foto is opgeslagen: " + photo.FullPath, "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Kon de camera niet openen: {ex.Message}", "OK");
            }
        }

    }
}
