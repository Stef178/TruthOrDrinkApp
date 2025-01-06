using SQLite;
using System;
using System.Collections.Generic;

namespace TruthOrDrinkApp.Models
{
    public class Session
    {
        [PrimaryKey, AutoIncrement]
        public int SessionID { get; set; }

        [NotNull]
        public int HostUserID { get; set; }

        [NotNull, MaxLength(50)]
        public string SessionCode { get; set; }

        [NotNull]
        public int DaringLevel { get; set; }

        [NotNull]
        public DateTime CreatedAt { get; set; }

        [Ignore]
        public User HostUser { get; set; }

        [Ignore]
        public ICollection<SessionQuestion> SessionQuestions { get; set; }

        [Ignore]
        public ICollection<QRInvitation> QRInvitations { get; set; }
    }
}
