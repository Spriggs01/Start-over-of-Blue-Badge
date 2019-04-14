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
        public int RecipeID { get; set; }

        [Display(Name = "Recipe Title")]
        public string RecipeTitle { get; set; }

        public string Link { get; set; }

        public int Calories { get; set; }

        [Display(Name ="Type of Meal (Ex:Breakfast/Lunch?)")]
        public string TypeName { get; set; }

        public string Dietary { get; set; }


        public string Image { get; set; }


       // public int MealID { get; set; }


        public override string ToString() => RecipeTitle;

        

    }
}
