using HealthyEats.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealtyEats.Models
{
    public class FavoriteRecipeEdit
    {
        public int FavoriteRecipeID { get; set; }

       // public int MealID { get; set; }

        [Display(Name = "Favorite List")]
        public string FavoriteList { get; set; }

        
        public int RecipeID { get; set; }

        [Display(Name = "Recipe Title")]
        public string RecipeTitle { get; set; }

    }
}
