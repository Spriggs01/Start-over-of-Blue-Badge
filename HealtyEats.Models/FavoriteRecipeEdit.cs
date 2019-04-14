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

        public int MealID { get; set; }

        [Display(Name = "Favorite List")]
        public string FavoriteList { get; set; }

        [Display(Name = "Name of Recipe")]
        public string RecipeTitle { get; set; }

        //public int RecipeID { get; set; }

        public ICollection<Recipe> Recipes { get; set; }
    }
}
