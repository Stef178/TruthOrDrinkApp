using Microsoft.Maui.Controls;
using System.Collections.Generic;

namespace TruthOrDrinkApp
{
    public partial class SelectQuestionType : ContentPage
    {
        private readonly int _daringLevel;
        private readonly List<string> _selectedCategories;

        public SelectQuestionType(int daringLevel, List<string> selectedCategories)
        {
            InitializeComponent();
            _daringLevel = daringLevel;
            _selectedCategories = selectedCategories;
        }

        private async void OnNextButtonClicked(object sender, EventArgs e)
        {
            // Haal de geselecteerde vraagtypes op
            var personalizedSelected = PersonalizedCheckBox.IsChecked;
            var suggestedSelected = SuggestedCheckBox.IsChecked;

            // Maak een object van de geselecteerde data
            var selectedData = new
            {
                DaringLevel = _daringLevel,
                SelectedCategories = _selectedCategories,
                Personalized = personalizedSelected,
                Suggested = suggestedSelected
            };

            // Navigeren naar MakeSessionPage en data doorgeven
            await Navigation.PushAsync(new MakeSessionPage(selectedData));
        }
    }
}
