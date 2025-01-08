using TruthOrDrinkApp.Data;
using TruthOrDrinkApp.Models;

namespace TruthOrDrinkApp
{
    public partial class SelectQuestionType : ContentPage
    {
        private readonly int _daringLevel;
        private readonly Constants _database;

        public SelectQuestionType(int daringLevel, Constants database)
        {
            InitializeComponent();
            _daringLevel = daringLevel;
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
                QuestionTypes = questionTypes
            };

            if (questionTypes == QuestionTypes.PERSONALIZED)
            {

                await Navigation.PushAsync(new MakeSessionPage(selectedData, _database));
            }
            else {
                await Navigation.PushAsync(new ChooseQuestionCategoryPage(_daringLevel, questionTypes, _database));
            }
        }
    }
}
