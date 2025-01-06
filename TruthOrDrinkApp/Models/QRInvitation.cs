using SQLite;
using System;

namespace TruthOrDrinkApp.Models
{
    public class QRInvitation
    {
        [PrimaryKey, AutoIncrement]
        public int QRInvitationID { get; set; }

        [NotNull]
        public int SessionID { get; set; }

        [NotNull]
        public string QRCodeData { get; set; }

        [NotNull]
        public DateTime GeneratedAt { get; set; }

        [Ignore]
        public Session Session { get; set; }
    }
}
