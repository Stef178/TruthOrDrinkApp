using TruthOrDrinkApp.Data;

namespace TruthOrDrinkApp
{
    public partial class NewGamePage : ContentPage
    {
        private int _daringLevel = 0;
        private readonly Constants _database;

        public NewGamePage(Constants database)
        {
            InitializeComponent();
            _database = database;
        }

        
        private void OnStarClicked(object sender, EventArgs e)
        {
            if (sender is Button button && int.TryParse(button.CommandParameter.ToString(), out int selectedLevel))
            {
                _daringLevel = selectedLevel;
                SelectedLevelLabel.Text = $"Gewaagdheidsniveau: {_daringLevel}";

                
                UpdateStarSelection(_daringLevel);
            }
        }

        // Slaat geselecteerde sterren visueel op
        private void UpdateStarSelection(int level)
        {
            Star1.Text = level >= 1 ? "★" : "★";
            Star2.Text = level >= 2 ? "★" : "★";
            Star3.Text = level >= 3 ? "★" : "★";
        }

        
        private async void OnNextButtonClicked(object sender, EventArgs e)
        {
            if (_daringLevel == 0)
            {
                await DisplayAlert("Fout", "Kies een gewaagdheidsniveau.", "OK");
                return;
            }

            // Debugging: Toon geselecteerde waarde
            Console.WriteLine($"Gewaagdheidsniveau gekozen: {_daringLevel}");

        
            await Navigation.PushAsync(new SelectQuestionType(_daringLevel, _database));
        }

    }
}
