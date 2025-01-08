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

        [Ignore]
        public ICollection<Category> Categories { get; set; } = new List<Category>();

        [NotNull]
        public QuestionTypes QuestionTypes { get; set; }

        [Ignore]
        public ICollection<SessionQuestion> SessionQuestions { get; set; }
    }
}
