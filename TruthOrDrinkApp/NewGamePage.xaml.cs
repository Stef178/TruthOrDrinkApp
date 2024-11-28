using Microsoft.Maui.Controls;

namespace TruthOrDrinkApp
{
    public partial class NewGamePage : ContentPage
    {
        public NewGamePage()
        {
            InitializeComponent();
        }

        // Navigeren naar VraagcategorieKiezenPage
        private async void OnNextButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChooseQuestionCategoryPage());
        }
    }
}
