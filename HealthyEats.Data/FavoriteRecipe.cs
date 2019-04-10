using HealthyEats.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyEats.WebMVC.Data
{
    public class FavoriteRecipe
    {
        [Key]
        public int FavoriteRecipeID { get; set; }

        public int  RecipeID { get; set; }


        public string FavoriteList { get; set; }

        [Required]
        public Guid UserID { get; set; }

        [ForeignKey("FavoriteRecipeRefID")]
        public virtual ICollection<Recipe> Recipes { get; set; }

    }
}
