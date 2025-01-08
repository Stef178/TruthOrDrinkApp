using System.Collections.ObjectModel;
using TruthOrDrinkApp.Data;
using TruthOrDrinkApp.Models;
using TruthOrDrinkApp.ViewModels;

namespace TruthOrDrinkApp
{
    public partial class ChooseQuestionCategoryPage : ContentPage
    {
        private readonly int _daringLevel;
        private readonly QuestionTypes _questionTypes;
        private readonly Constants _database;
        public ObservableCollection<CategoryViewModel> Categories { get; set; }

        public ChooseQuestionCategoryPage(int daringLevel, QuestionTypes questionTypes, Constants database)
        {
            InitializeComponent();
            _daringLevel = daringLevel;
            _questionTypes = questionTypes;
            _database = database;
            List<Category> categories = Task.Run(async () => await GetCategories()).Result;
            Categories = new ObservableCollection<CategoryViewModel>(
                categories.Select(c => new CategoryViewModel(c))
            );
            BindingContext = this;

            // Debugging: Laat zien welk gewaagdheidsniveau is ontvangen
            Console.WriteLine($"Ontvangen gewaagdheidsniveau: {_daringLevel}");
        }

        private async void OnNextButtonClicked(object sender, EventArgs e)
        {
            List<Category> selectedCategories = Categories
            .Where(vm => vm.IsChecked)
            .Select(vm => vm.Category)
            .ToList();

            // Controleer of minstens één categorie is geselecteerd
            if (selectedCategories.Count == 0)
            {
                await DisplayAlert("Fout", "Selecteer minstens één categorie.", "OK");
                return;
            }

            // Debugging: Toon geselecteerde categorieën
            Console.WriteLine("Geselecteerde categorieën: " + string.Join(", ", selectedCategories));

            var selectedData = new
            {
                DaringLevel = _daringLevel,
                QuestionTypes = _questionTypes,
                SelectedCategories = selectedCategories
            };

            // Navigeer naar de volgende pagina met geselecteerde gegevens
            await Navigation.PushAsync(new MakeSessionPage(selectedData, _database));
        }

        private async Task<List<Category>> GetCategories()
        {
            return _database.GetAllAsync<Category>().Result;
        }
    }
}
