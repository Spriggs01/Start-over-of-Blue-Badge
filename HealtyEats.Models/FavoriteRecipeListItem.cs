using HealthyEats.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealtyEats.WebMVC.Models
{
    public class FavoriteRecipeListItem
    {
        public int FavoriteRecipeID { get; set; }
        public string FavoriteList { get; set; }
        public int  RecipeID { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
