namespace TruthOrDrinkApp
{
    public partial class NewGamePage : ContentPage
    {
        private int _daringLevel = 0; // Gekozen gewaagdheidsniveau

        public NewGamePage()
        {
            InitializeComponent();
        }

        // Sterren klikken
        private void OnStarClicked(object sender, EventArgs e)
        {
            if (sender is Button button && int.TryParse(button.CommandParameter.ToString(), out int selectedLevel))
            {
                _daringLevel = selectedLevel;
                SelectedLevelLabel.Text = $"Gewaagdheidsniveau: {_daringLevel}";

                // Optioneel: Markeer geselecteerde sterren
                UpdateStarSelection(_daringLevel);
            }
        }

        // Slaat geselecteerde sterren visueel op
        private void UpdateStarSelection(int level)
        {
            Star1.Text = level >= 1 ? "★" : "★";
            Star2.Text = level >= 2 ? "★" : "★";
            Star3.Text = level >= 3 ? "★" : "★";
            Star4.Text = level >= 4 ? "★" : "★";
            Star5.Text = level >= 5 ? "★" : "★";
        }

        // Volgende knop
        private async void OnNextButtonClicked(object sender, EventArgs e)
        {
            if (_daringLevel == 0)
            {
                await DisplayAlert("Fout", "Kies een gewaagdheidsniveau.", "OK");
                return;
            }

            // Debugging: Toon geselecteerde waarde
            Console.WriteLine($"Gewaagdheidsniveau gekozen: {_daringLevel}");

            // Navigeer naar de ChooseQuestionCategoryPage en geef het gewaagdheidsniveau door
            await Navigation.PushAsync(new ChooseQuestionCategoryPage(_daringLevel));
        }

    }
}
