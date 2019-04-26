using HealthyEats.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealtyEats.Models
{
    public class RecipeDetail
    {
        [Display(Name = "Meal Type")]
        public MealType NameOfMeal { get; set; }
        public int RecipeID { get; set; }
        public int MealID { get; set; }

        [Display(Name = "Recipe Title")]
        public string RecipeTitle { get; set; }

        public string Link { get; set; }

        public int Calories { get; set; }
        public string Dietary { get; set; }

        public override string ToString() => RecipeTitle;

    }
}
