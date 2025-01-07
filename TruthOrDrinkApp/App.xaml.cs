using TruthOrDrinkApp.Data;
using TruthOrDrinkApp.Models;
using System.Text.Json;
using Newtonsoft.Json.Linq;

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
            Console.WriteLine(dbPath);
            Database = new Constants(dbPath);
        }
    }
}
