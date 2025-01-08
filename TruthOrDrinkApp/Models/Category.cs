using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace TruthOrDrinkApp.Models
{
    public class Category
    {
        public Category(int id, string name, string label)
        {
            this.Id = id;
            this.Name = name;
            this.Label = label;
        }

        public Category(string name, string label)
        {
            this.Name = name;
            this.Label = label;
        }
        public Category()
        {
            
        }
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
    }
}
