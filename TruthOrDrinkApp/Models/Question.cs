using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;
using SQLite;

namespace TruthOrDrinkApp.Models
{
    public class Question
    {
        public Question(int questionId, string questionText)
        {
            QuestionID = questionId;
            QuestionText = questionText;
        }
        public Question(string questionText)
        {
            
            QuestionText = questionText;
        }
        public Question()
        {

          
        }

        [PrimaryKey, AutoIncrement]
        public int QuestionID { get; set; }

        [NotNull]
        [JsonPropertyName("question")]
        public string QuestionText { get; set; }
    }
}
