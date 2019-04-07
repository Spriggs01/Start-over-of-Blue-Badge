using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealtyEats.WebMVC.Models
{
    public class MealListItem
    {
        public int RecipeID { get; set; }
        public int  MealID { get; set; }
        public string MealDescription { get; set; }
    }
}
