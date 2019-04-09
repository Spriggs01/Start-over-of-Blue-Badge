using HealthyEats.WebMVC.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealtyEats.Models
{ 
    public class RecipeCreate
    {
        [Key]
        [Required]
        public string RecipeTitle { get; set; }

        public string  MealName { get; set; }

        public string MealDescription { get; set; }


        public string Link { get; set; }

        public int Calories { get; set; }

        public string TypeName { get; set; }

        public string Dietary { get; set; }

        public string Image { get; set; }

        public virtual ICollection<Meal> Meals { get; set; }

        public virtual ICollection<FavoriteRecipe> FavoriteRecipes { get; set; }

        public override string ToString() => RecipeTitle;

        

    }
}
