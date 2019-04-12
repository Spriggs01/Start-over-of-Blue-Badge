using HealthyEats.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealtyEats.WebMVC.Models
{
    public class FavoriteRecipeListItem
    {
       
        public int FavoriteRecipeID { get; set; }

        public int MealID { get; set; }

        [Display(Name = "Favorite List")]
        public string FavoriteList { get; set; }

        public int  RecipeID { get; set; }

        public Recipe Recipe { get; set; }

        public override string ToString() => FavoriteList;
       
    }
}
