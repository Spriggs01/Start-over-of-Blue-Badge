using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealtyEats.Models
{
   public class RecipeTypeCreate
    {

        public int RecipeTypeID { get; set; }

        [Required]
        public string TypeName { get; set; }

        [Required]
        public string Dietary { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
