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
        [Display(Name = "Recipe Name")]
        public int RecipeID { get; set; }

        [Display(Name = "Name of Recipe")]
        public string RecipeTitle { get; set; }

        [Display(Name = "Favorite List")]
        public string FavoriteList { get; set; }

        public override string ToString() => FavoriteList;
    }
}
