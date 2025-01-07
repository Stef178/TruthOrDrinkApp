using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TruthOrDrinkApp.Models
{
    public class SuggestedQuestion
    {
        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("correctAnswer")]
        public string CorrectAnswer { get; set; }

        [JsonPropertyName("incorrectAnswers")]
        public List<string> IncorrectAnswers { get; set; }

        [JsonPropertyName("question")]
        public string Question { get; set; }

        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("difficulty")]
        public string Difficulty { get; set; }

        [JsonPropertyName("regions")]
        public List<string> Regions { get; set; }

        [JsonPropertyName("isNiche")]
        public bool IsNiche { get; set; }
    }
}
