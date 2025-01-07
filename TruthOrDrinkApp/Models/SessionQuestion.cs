using SQLite;

namespace TruthOrDrinkApp.Models
{
    public class SessionQuestion
    {
        [PrimaryKey, AutoIncrement]
        public int SessionQuestionID { get; set; }

        [NotNull]
        public int SessionID { get; set; }

        [NotNull]
        public int QuestionID { get; set; }

        [Ignore]
        public Session Session { get; set; }

        [Ignore]
        public Question Question { get; set; }
    }
}
