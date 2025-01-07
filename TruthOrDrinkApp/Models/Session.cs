using Newtonsoft.Json;
using SQLite;
using System.Collections.Generic;

namespace TruthOrDrinkApp.Models
{
    public class Session
    {
        [PrimaryKey, AutoIncrement]
        public int SessionID { get; set; }

        [NotNull]
        public string SessionCode { get; set; }

        [NotNull]
        public int DaringLevel { get; set; }

        // JSON-serialisatie voor de Categories-collectie
        [NotNull]
        public string CategoriesJson
        {
            get => JsonConvert.SerializeObject(Categories);
            set => Categories = string.IsNullOrEmpty(value)
                ? new List<string>()
                : JsonConvert.DeserializeObject<ICollection<string>>(value);
        }

        // Wordt niet direct opgeslagen in SQLite
        [Ignore]
        public ICollection<string> Categories { get; set; } = new List<string>();

        [NotNull]
        public QuestionTypes QuestionTypes { get; set; }

        [Ignore]
        public ICollection<SessionQuestion> SessionQuestions { get; set; }
    }
}
