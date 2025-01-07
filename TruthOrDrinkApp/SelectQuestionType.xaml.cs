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

            // Debugging: Toon de ontvangen gegevens
            Console.WriteLine($"Gewaagdheidsniveau: {_daringLevel}");
            Console.WriteLine("Categorieën: " + string.Join(", ", _selectedCategories));
        }
    }
}
