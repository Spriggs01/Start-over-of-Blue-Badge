using HealthyEats.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealtyEats.Models
{
    public class FavoriteRecipeDetail
    {
        public int RecipeID { get; set; }

        public int FavoriteRecipeID { get; set; }

        [Display(Name = "Favorite List")]
        public string FavoriteList { get; set; }

        public override string ToString() => $"[{FavoriteRecipeID} {RecipeID}] {FavoriteList}";
    }
}
