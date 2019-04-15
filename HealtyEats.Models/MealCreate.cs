using HealthyEats.Data;
using HealthyEats.WebMVC.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealtyEats.Models
{
    public class MealCreate
    {


        [Display(Name = "Type of Meal (Ex: Breakfast")]
        public string MealName { get; set; }

        [Display(Name = "Meal Description")]
        public string MealDescription { get; set; }

        [Display(Name = "Recipe Title")]
        public string RecipeTitle { get; set; }

        public ICollection<Recipe> Recipes { get; set; }


        public override string ToString() => MealName;
    }
}
