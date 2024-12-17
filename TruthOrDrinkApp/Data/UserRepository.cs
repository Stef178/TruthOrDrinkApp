using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using TruthOrDrinkApp.Models;

namespace TruthOrDrinkApp.Models
{

    public class UserRepository
    {
        private readonly SQLiteConnection connection;
        public string? StatusMessage { get; set; }

        public UserRepository(string dbPath)
        {
            // Initialize SQLite connection and create User table
            connection = new SQLiteConnection(dbPath);
            connection.CreateTable<User>();
        }

        public void AddOrUpdate(User user)
        {
            try
            {
                if (user.Id == 0)
                {
                    // Add new user
                    connection.Insert(user);
                    StatusMessage = "User successfully added.";
                }
                else
                {
                    // Update existing user
                    connection.Update(user);
                    StatusMessage = "User successfully updated.";
                }
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }

        public List<User> GetAll()
        {
            try
            {
                // Return all users
                return connection.Table<User>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
                return new List<User>();
            }
        }

        public User? Get(int id)
        {
            try
            {
                // Retrieve user by ID
                return connection.Table<User>().FirstOrDefault(u => u.Id == id);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
                return null;
            }
        }

        public void Delete(int userId)
        {
            try
            {
                // Retrieve the user and delete them
                User? user = Get(userId);
                if (user != null)
                {
                    connection.Delete(user);
                    StatusMessage = "User successfully deleted.";
                }
                else
                {
                    StatusMessage = "User not found.";
                }
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }
    }
}



