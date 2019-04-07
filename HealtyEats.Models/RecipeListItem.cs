using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealtyEats.Models
{
  public  class RecipeListItem
    {
        public string RecipeTitle { get; set; }
        public int Calories { get; set; }
        public string Link { get; set; }
        public string Image { get; set; }
    }
}
