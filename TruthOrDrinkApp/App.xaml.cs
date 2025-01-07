using Microsoft.Maui.Controls;
using TruthOrDrinkApp.Data;
using System.IO;

namespace TruthOrDrinkApp
{
    public partial class App : Application
    {
        public static Constants Database { get; private set; }

        public App()
        {
            InitializeComponent();
            InitializeDatabase();

            // Startpagina instellen
            MainPage = new NavigationPage(new LoginPage(Database));
        }

        private void InitializeDatabase()
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "TruthOrDrink.db");
            Database = new Constants(dbPath);
        }
    }
}
