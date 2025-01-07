using Microsoft.Maui.Controls;
using System.Collections.Generic;

namespace TruthOrDrinkApp
{
    public partial class ChooseQuestionCategoryPage : ContentPage
    {
        private readonly int _daringLevel;

        public ChooseQuestionCategoryPage(int daringLevel)
        {
            InitializeComponent();
            _daringLevel = daringLevel;

            // Debugging: Laat zien welk gewaagdheidsniveau is ontvangen
            Console.WriteLine($"Ontvangen gewaagdheidsniveau: {_daringLevel}");
        }

        private async void OnNextButtonClicked(object sender, EventArgs e)
        {
            // Verzamel geselecteerde categorie�n
            var selectedCategories = new List<string>();
            if (HappyHourCheckBox.IsChecked) selectedCategories.Add("Happy Hour");
            if (OnTheRocksCheckBox.IsChecked) selectedCategories.Add("On the Rocks");
            if (LastCallCheckBox.IsChecked) selectedCategories.Add("Last Call");
            if (ExtraViesCheckBox.IsChecked) selectedCategories.Add("Extra Vies");

            // Controleer of minstens ��n categorie is geselecteerd
            if (selectedCategories.Count == 0)
            {
                await DisplayAlert("Fout", "Selecteer minstens ��n categorie.", "OK");
                return;
            }

            // Debugging: Toon geselecteerde categorie�n
            Console.WriteLine("Geselecteerde categorie�n: " + string.Join(", ", selectedCategories));

            // Navigeer naar de volgende pagina met geselecteerde gegevens
            await Navigation.PushAsync(new SelectQuestionType(_daringLevel, selectedCategories));
        }
    }
}
