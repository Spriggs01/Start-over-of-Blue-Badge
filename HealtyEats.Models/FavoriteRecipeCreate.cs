using HealthyEats.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealtyEats.Models
{
    public class FavoriteRecipeCreate
    {
        [Display(Name = "Recipe Title")]
        public int RecipeID { get; set; }

        public int FavoriteRecipeID { get; set; }

        [Display(Name = "Favorite List")]
        public string FavoriteList { get; set; }

        [Display(Name = "Recipe Title")]
        public string RecipeTitle { get; set; }


        public override string ToString() => FavoriteList;
    }
}
