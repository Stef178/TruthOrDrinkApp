using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using SQLite;

namespace TruthOrDrinkApp.Models
{
    public class SuggestedQuestion : Question
    {
        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("difficulty")]
        public string Difficulty { get; set; }

        [JsonPropertyName("isNiche")]
        public bool IsNiche { get; set; }

        [NotNull]
        public int SessionID { get; set; }

        [NotNull]
        [JsonPropertyName("correctAnswer")]
        public string Answer { get; set; }
    }
}
