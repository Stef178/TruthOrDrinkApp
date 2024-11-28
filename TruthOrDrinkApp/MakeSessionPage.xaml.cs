namespace TruthOrDrinkApp;

public partial class MakeSessionPage : ContentPage
{
	public MakeSessionPage()
	{
		InitializeComponent();
	}

    private async void OnNextButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FillQuestionPool());
    }
}