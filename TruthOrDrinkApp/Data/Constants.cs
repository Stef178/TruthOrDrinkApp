using SQLite;
using TruthOrDrinkApp.Models;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace TruthOrDrinkApp.Data
{
    public class Constants
    {
        private readonly SQLiteAsyncConnection _database;

        public Constants(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);

            try
            {
                // Tabellen maken
                _database.CreateTableAsync<User>().Wait();
                _database.CreateTableAsync<Session>().Wait();
                _database.CreateTableAsync<Question>().Wait();
                _database.CreateTableAsync<SessionQuestion>().Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating tables: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
                throw;
            }
        }

        public async Task ResetDatabaseAsync()
        {
            await _database.DropTableAsync<Session>();
            await _database.DropTableAsync<User>();
            await _database.DropTableAsync<Question>();
            await _database.DropTableAsync<SessionQuestion>();

            await _database.CreateTableAsync<User>();
            await _database.CreateTableAsync<Session>();
            await _database.CreateTableAsync<Question>();
            await _database.CreateTableAsync<SessionQuestion>();
        }

        public Task<List<T>> GetAllAsync<T>() where T : new()
        {
            return _database.Table<T>().ToListAsync();
        }

        public Task<int> AddAsync<T>(T item) where T : new()
        {
            return _database.InsertAsync(item);
        }

        public Task<int> UpdateAsync<T>(T item) where T : new()
        {
            return _database.UpdateAsync(item);
        }

        public Task<int> DeleteAsync<T>(T item) where T : new()
        {
            return _database.DeleteAsync(item);
        }

        public Task<int> AddAllAsync<T>(IEnumerable<T> items) where T : new()
        {
            return _database.InsertAllAsync(items);
        }
    }
}
