namespace TruthOrDrinkApp;

public partial class GameStartedxaml : ContentPage
{
	public GameStartedxaml()
	{
		InitializeComponent();
	}

    private async void BackToHomeClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}