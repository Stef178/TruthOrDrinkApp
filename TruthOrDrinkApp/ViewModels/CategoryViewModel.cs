using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruthOrDrinkApp.Models;

namespace TruthOrDrinkApp.ViewModels
{
    public class CategoryViewModel
    {
        public Category Category { get; set; }
        public bool IsChecked { get; set; }

        public CategoryViewModel(Category category)
        {
            Category = category;
        }
    }

    
}
