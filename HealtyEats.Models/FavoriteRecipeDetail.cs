using HealthyEats.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealtyEats.Models
{
    public class FavoriteRecipeDetail
    {
        public int RecipeID { get; set; }

        public int FavoriteRecipeID { get; set; }

        public string FavoriteList { get; set; }

        public override string ToString() => $"[{FavoriteRecipeID} {RecipeID}] {FavoriteList}";
    }
}
