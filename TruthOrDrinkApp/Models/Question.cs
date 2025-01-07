using SQLite;

namespace TruthOrDrinkApp.Models
{
    public class Question
    {
        [PrimaryKey, AutoIncrement]
        public int QuestionID { get; set; }

        [NotNull]
        public string QuestionText { get; set; }

        [NotNull]
        public string QuestionType { get; set; }

        public string Category { get; set; }

        [NotNull]
        public int DaringLevel { get; set; }

        public int? CreatedByUserID { get; set; }

        [Ignore]
        public User CreatedByUser { get; set; }

        [Ignore]
        public ICollection<SessionQuestion> SessionQuestions { get; set; }
    }
}
