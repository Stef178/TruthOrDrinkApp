using System;
using System.IO;
using SQLite;
using TruthOrDrinkApp.Models;

namespace TruthOrDrinkApp.Data
{
    public class Constants
    {

        private readonly SQLiteAsyncConnection _database;

        public Constants(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);



            _database.CreateTableAsync<User>().Wait();

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
