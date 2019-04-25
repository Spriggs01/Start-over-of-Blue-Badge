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
    public class RecipeCreate
    {
        [Display (Name ="Meal Type")]
        public MealType NameOfMeal { get; set; }
        public int RecipeID { get; set; }

        [Display(Name = "Recipe Title")]
        public string RecipeTitle { get; set; }

        public string Link { get; set; }

        public int Calories { get; set; }


        public string Dietary { get; set; }


      //  public string Image { get; set; }

        [Display(Name = "Type of Meal (Ex: Breakfast/Lunch/Dinner?")]
        public int MealID { get; set; }


        public override string ToString() => RecipeTitle;

        

    }
}
