using HealthyEats.WebMVC.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyEats.Data
{
    public class Recipe
    {
        public Recipe()
        {
            this.Meals = new HashSet<Meal>();
            this.FavoriteRecipes = new HashSet<FavoriteRecipe>();
        }
        [Required]
        public Guid UserID { get; set; }

        
        public int RecipeID { get; set; }

        [Key]
        [Required]
        public string RecipeTitle { get; set; }

        
        public string Link { get; set; }

        public int Calories { get; set; }

        public string TypeName { get; set; }

        public string Dietary { get; set; }

       

        [Required]
        public int RecipeTypeID { get; set; }

        public virtual ICollection<Meal> Meals { get; set; }

        public virtual ICollection<FavoriteRecipe> FavoriteRecipes { get; set; }


    }
}
