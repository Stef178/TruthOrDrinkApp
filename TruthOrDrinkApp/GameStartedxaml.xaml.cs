using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TruthOrDrinkApp.Models;
using Microsoft.Maui.Controls;

namespace TruthOrDrinkApp
{
    public partial class GameStartedxaml : ContentPage
    {
        private static readonly HttpClient client = new HttpClient();
        private List<SuggestedQuestion> questions;
        private int currentQuestionIndex = 0;

        public GameStartedxaml()
        {
            InitializeComponent();
            LoadQuestions();
        }

        private async void LoadQuestions()
        {
            try
            {
                // API-aanroep om vragen op te halen
                var response = await client.GetStringAsync("https://the-trivia-api.com/api/questions?categories=sport_and_leisure&limit=5&region=NL&difficulty=medium");

                // Controleer de respons om te zorgen dat deze correct is
                Console.WriteLine(response);

                // JSON-parsing naar de SuggestedQuestion lijst
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true // Negeer hoofdlettergevoeligheid
                };

                questions = JsonSerializer.Deserialize<List<SuggestedQuestion>>(response, options);

                // Controleer of er vragen zijn
                if (questions != null && questions.Count > 0)
                {
                    DisplayCurrentQuestion();
                }
                else
                {
                    Console.WriteLine("Geen vragen gevonden.");
                }
            }
            catch (Exception ex)
            {
                // Foutafhandeling
                Console.WriteLine($"Er is een fout opgetreden: {ex.Message}");
            }
        }

        private void DisplayCurrentQuestion()
        {
            var currentQuestion = questions[currentQuestionIndex];

            // Zet de vraag en het juiste antwoord in de labels
            QuestionLabel.Text = currentQuestion.Question;
            AnswerLabel.Text = "Correct Antwoord: " + currentQuestion.CorrectAnswer;
        }

        private void NextQuestionButton_Clicked(object sender, EventArgs e)
        {
            // Ga naar de volgende vraag
            if (currentQuestionIndex < questions.Count - 1)
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
