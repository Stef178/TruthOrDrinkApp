namespace TruthOrDrinkApp;

public partial class SelectQuestionType : ContentPage
{
	public SelectQuestionType()
	{
		InitializeComponent();
	}
    private async void OnNextButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MakeSessionPage());
    }
}