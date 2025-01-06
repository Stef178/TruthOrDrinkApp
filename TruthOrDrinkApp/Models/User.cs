using SQLite;

namespace TruthOrDrinkApp.Models
{
    [Table("User")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Column("name"), Indexed, NotNull]
        public string? Name { get; set; }

        [Unique, NotNull]
        public string? Email { get; set; } // Gebruikers inloggen met e-mail

        [NotNull]
        public string Password { get; set; } // Wachtwoord als plain text (simpel)

        [Unique]
        public string? Phone { get; set; }

        [MaxLength(100)]
        public string? Address { get; set; }

        public int? Age { get; set; }

        [Ignore]
        public bool? OldEnoughToDrink => Age > 17;
    }
}
