using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealtyEats.Models
{
    public class MealCreate
    {
        public int RecipeID { get; set; }
        public int  MealID { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
