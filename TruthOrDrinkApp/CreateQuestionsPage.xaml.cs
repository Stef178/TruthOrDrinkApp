using TruthOrDrinkApp.Data;
using TruthOrDrinkApp.Models;

namespace TruthOrDrinkApp
{
    public partial class CreateQuestionsPage : ContentPage
    {
        private readonly Constants _database;

        public CreateQuestionsPage(Constants database)
        {
            InitializeComponent();
            _database = database;
        }

        private async void OnAddQuestionClicked(object sender, EventArgs e)
        {
            var questionText = QuestionEntry.Text;
            if (!string.IsNullOrEmpty(questionText))
            {
                var newQuestion = new Question(questionText);
                await _database.AddAsync(newQuestion);
                QuestionEntry.Text = string.Empty;
            }
        }
    }
}
