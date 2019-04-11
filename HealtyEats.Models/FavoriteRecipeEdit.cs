using HealthyEats.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealtyEats.Models
{
    public class FavoriteRecipeEdit
    {
        public int FavoriteRecipeID { get; set; }

        public int MealID { get; set; }

        public string FavoriteList { get; set; }

        public int RecipeID { get; set; }

    }
}
