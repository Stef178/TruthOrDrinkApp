using TruthOrDrinkApp.Data;
using TruthOrDrinkApp.Models;

namespace TruthOrDrinkApp
{
    public partial class SelectQuestionType : ContentPage
    {
        private readonly int _daringLevel;
        private readonly List<string> _selectedCategories;
        private readonly Constants _database;

        public SelectQuestionType(int daringLevel, List<string> selectedCategories, Constants database)
        {
            InitializeComponent();
            _daringLevel = daringLevel;
            _selectedCategories = selectedCategories;
            _database = database;
        }

        private async void OnNextButtonClicked(object sender, EventArgs e)
        {
            // Haal de geselecteerde vraagtypes op
            var personalizedSelected = PersonalizedCheckBox.IsChecked;
            var suggestedSelected = SuggestedCheckBox.IsChecked;

            QuestionTypes questionTypes;
            if (personalizedSelected && suggestedSelected)
            {
                questionTypes = QuestionTypes.PERSONALIZED_AND_SUGGESTED;
            }
            else if (personalizedSelected){ 
                questionTypes = QuestionTypes.PERSONALIZED;
            }
            else
            {
                questionTypes = QuestionTypes.SUGGESTED;

            }
            // Maak een object van de geselecteerde data
            var selectedData = new
            {
                DaringLevel = _daringLevel,
                SelectedCategories = _selectedCategories,
                QuestionTypes = questionTypes
            };

            // Navigeren naar MakeSessionPage en data doorgeven
            await Navigation.PushAsync(new MakeSessionPage(selectedData, _database));
        }
    }
}
