using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TruthOrDrinkApp.Models;
using Microsoft.Maui.Controls;
using Bogus;
using TruthOrDrinkApp.Data;
using Bogus.DataSets;
using System.Collections.ObjectModel;

namespace TruthOrDrinkApp
{
    public partial class GameStartedxaml : ContentPage
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly Constants _database;
        private List<Question> _questions = new List<Question>();
        private int currentQuestionIndex = 0;
        private readonly Session _session;
        private readonly List<Category> _categories;

        public GameStartedxaml(Session session, Constants database, QuestionTypes questionTypes, List<Category> categories)
        {
            InitializeComponent();
            _session = session;
            _database = database;
            _categories = categories;

            if (questionTypes == QuestionTypes.SUGGESTED)
            {
                List<SuggestedQuestion> questions = Task.Run(async () => await GetSuggestedQuestions()).Result;
                questions.ForEach(question => _questions.Add(question));

            }
            else if (questionTypes == QuestionTypes.PERSONALIZED)
            {
                List<Question> questions = Task.Run(async () => await GetQuestions()).Result;
                questions.ForEach(question => _questions.Add(question));
            }
            else
            {
                List<Question> questions = Task.Run(async () => await GetQuestions()).Result;
                questions.ForEach(question => _questions.Add(question));
                List<SuggestedQuestion> suggestedquestions = Task.Run(async () => await GetSuggestedQuestions()).Result;
                suggestedquestions.ForEach(question => _questions.Add(question));

            }

            DisplayCurrentQuestion();
        }

        private async Task<List<Question>> GetQuestions()
        {
            return _database.GetAllAsync<Question>().Result;
           
        }
        private async Task<List<SuggestedQuestion>> GetSuggestedQuestions()
        {
            try
            {
                // API-aanroep om vragen op te halen
                var response = await client.GetStringAsync($"https://the-trivia-api.com/api/questions?categories={string.Join(",",_categories.Select(category => category.Name))}&limit=5&region=NL&difficulty=medium");

                // Controleer de respons om te zorgen dat deze correct is
                Console.WriteLine(response);

                // JSON-parsing naar de SuggestedQuestion lijst
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true // Negeer hoofdlettergevoeligheid
                };

                List<SuggestedQuestion> suggestedQuestions = JsonSerializer.Deserialize<List<SuggestedQuestion>>(response, options);
                suggestedQuestions.ForEach(question => question.SessionID = _session.SessionID);
                await _database.AddAllAsync<SuggestedQuestion>(suggestedQuestions);
                return suggestedQuestions;
            }
            catch (Exception ex)
            {
                // Foutafhandeling
                Console.WriteLine($"Er is een fout opgetreden: {ex.Message}");
                return new List<SuggestedQuestion>();
            }
        }

        private void DisplayCurrentQuestion()
        {
            var currentQuestion = _questions[currentQuestionIndex];

            // Zet de vraag en het juiste antwoord in de labels
            QuestionLabel.Text = currentQuestion.QuestionText;
            AnswerLabel.Text = currentQuestion.GetType() == typeof(SuggestedQuestion) ? "Correct Antwoord: " + ((SuggestedQuestion) currentQuestion).Answer : "";
        }

        private void NextQuestionButton_Clicked(object sender, EventArgs e)
        {
            // Ga naar de volgende vraag
            if (currentQuestionIndex < _questions.Count - 1)
            {
                currentQuestionIndex++;
                DisplayCurrentQuestion();
            }
            else
            {
                // Geen vragen meer
                QuestionLabel.Text = "Geen verdere vragen!";
                AnswerLabel.Text = string.Empty;
                NextQuestionButton.IsVisible = false; // Verberg de knop
            }
        }
    }
}
