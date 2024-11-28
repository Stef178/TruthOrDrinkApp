using Microsoft.Maui.Controls;

namespace TruthOrDrinkApp
{
    public partial class ChooseQuestionCategoryPage : ContentPage
    {
        public ChooseQuestionCategoryPage()
        {
            InitializeComponent();

        }

        private async void OnNextButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SelectQuestionType());
        }
    }
}
