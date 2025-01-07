using Microsoft.Maui.Controls;
using System;

namespace TruthOrDrinkApp
{
    public partial class MakeSessionPage : ContentPage
    {
        private readonly dynamic _selectedData;

        public MakeSessionPage(dynamic selectedData)
        {
            InitializeComponent();
            _selectedData = selectedData;

            // Toon de geselecteerde gegevens in de labels
            DaringLevelLabel.Text = $"Gewaagdheidsniveau: {_selectedData.DaringLevel}";
            CategoriesLabel.Text = "Geselecteerde categorieën: " + string.Join(", ", _selectedData.SelectedCategories);
            QuestionTypeLabel.Text = $"Gepersonaliseerd: {_selectedData.Personalized}, Voorgestelde: {_selectedData.Suggested}";
        }

        private async void OnNextButtonClicked(object sender, EventArgs e)
        {
            // Hier kun je de logica voor de QR-code toevoegen
            await Navigation.PushAsync(new FillQuestionPool());
        }
    }
}
