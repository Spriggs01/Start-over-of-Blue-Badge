using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealtyEats.Models
{
  public  class RecipeCreate
    {
        [Required]
        public string RecipeTitle { get; set; }
        public string Link { get; set; }
        public int Calories { get; set; }
        public string RecipeType { get; set; }
        public string Image { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
