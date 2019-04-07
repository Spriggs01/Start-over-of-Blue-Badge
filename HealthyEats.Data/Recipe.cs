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
        [Key]
        public int RecipeID { get; set; }

        [Required]
        public string RecipeTitle { get; set; }

        [Required]
        public string Link { get; set; }

        public int Calories { get; set; }

        [Required]
        public int RecipeTypeID { get; set; }

        [Required]
        public string Image { get; set; }

    }
}
