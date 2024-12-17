using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace TruthOrDrinkApp.Data
{
    public class UserRepository
    {
        SQLiteConnection connection;

        public UserRepository()
        {
            connection = new SQLiteConnection(
                Constants.DatabasePath,
                Constants.flags);
        }
    }
}

