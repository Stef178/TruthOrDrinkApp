namespace TruthOrDrinkApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("MainPage", typeof(MainPage));
            Routing.RegisterRoute("Settings", typeof(Settings));
            Routing.RegisterRoute("Help", typeof(Help));
        }
    }
}
