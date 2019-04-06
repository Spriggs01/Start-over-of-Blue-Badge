using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyEats.Data
{
    public enum MealType
    {
        mealType, MealDescription

    }

    public class Meal
    {
        [Required]
        public Guid UserID { get; set; }

        [Required]
        public int RecipeID { get; set; }

        [Key]
        public int MealID { get; set; }

        [Required]
        public MealType TypeOfMeal { get; set; }
    }
}
