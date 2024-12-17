using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using TruthOrDrinkApp.Models;

namespace TruthOrDrinkApp.Data
{
    public class UserRepository
    {
        SQLiteConnection connection;
        public string? statusMessage { get; set; }

        public UserRepository()
        {
            connection = new SQLiteConnection(
                Constants.DatabasePath,
                Constants.flags);
            connection.CreateTable<User>();
        }

        public void Add(User newUser)
        {
            int result = 0;
            try
            {
                result = connection.Insert(newUser);
                statusMessage = $"{result} row(s) added";
            }
            catch (Exception ex)
            {
                statusMessage = $"Error: {ex.Message}";
            }
        }
    }
}


