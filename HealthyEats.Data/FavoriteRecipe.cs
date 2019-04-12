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
        



        [Key]
        public int FavoriteRecipeID { get; set; }

       [Display(Name = "Recipe Title")]
        public string RecipeTitle { get; set; }

        [Display(Name = "Favorite List")]
        public string FavoriteList { get; set; }

        public int RecipeID { get; set; }


        [Required]
        public Guid UserID { get; set; }


        public virtual Recipe Recipe { get; set; }

    }
}
