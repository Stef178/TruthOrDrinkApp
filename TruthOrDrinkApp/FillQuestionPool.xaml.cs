namespace TruthOrDrinkApp;

public partial class FillQuestionPool : ContentPage
{
    public FillQuestionPool()
    {
        InitializeComponent();
    }

    private async void OnNextButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new GameStartedxaml());
    }
}