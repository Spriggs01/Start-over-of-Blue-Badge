using HealthyEats.WebMVC.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyEats.Data
{
    public enum MealType
    {
        Breakfast, Lunch, Dinner, Snack, Desert
    }
    public class Recipe
    {

        [Required]
        public Guid UserID { get; set; }

        [Key]
        public int RecipeID { get; set; }
        
        public int MealID { get; set; }

        [Required]
        public string RecipeTitle { get; set; }
        
        public string Link { get; set; }

        public int Calories { get; set; }

       public string Dietary { get; set; }

        
        public virtual Meal Meal { get; set; }
        public MealType NameOfMeal { get; set; }

        public override string ToString() => RecipeTitle;
    }
}
