using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace TruthOrDrinkApp.Models
{
    internal class SessionCategory
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int SessionId { get; set; }

        public int CategoryId { get; set; }

    }
}
