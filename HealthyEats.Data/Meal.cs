using HealthyEats.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyEats.WebMVC.Data
{
    public enum TypeOfMeal
    {
        Breakfast, Lunch, Dinner, Snack, Desert
    }
    public class Meal
    {


        [Required]
        public Guid UserID { get; set; }

        [Key]
        public int MealID { get; set; }

        public TypeOfMeal MealName { get; set; }

        public string RecipeTitle { get; set; }

        public string MealDescription { get; set; }

        //public ICollection<Recipe> Recipes { get; set; }
    }
}
