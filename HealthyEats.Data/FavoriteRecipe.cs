using HealthyEats.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyEats.WebMVC.Data
{
    public class FavoriteRecipe
    {
        public FavoriteRecipe()
        {
            this.Recipes = new HashSet<Recipe>();
        }



        [Key]
        public int FavoriteRecipeID { get; set; }

        public string FavoriteList { get; set; }

        public int RecipeID { get; set; }


        [Required]
        public Guid UserID { get; set; }


        public virtual ICollection<Recipe> Recipes { get; set; }

    }
}
