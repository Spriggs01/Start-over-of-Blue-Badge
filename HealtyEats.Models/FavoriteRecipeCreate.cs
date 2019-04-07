using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealtyEats.Models
{
    public class FavoriteRecipeCreate
    {
        
        [Required]
        public int RecipeID { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
