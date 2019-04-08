using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealtyEats.Models
{
    public class RecipeDetail
    {
        public int RecipeID { get; set; }
        public string RecipeTitle { get; set; }
        public string Link { get; set; }
        public int Calories { get; set; }
        public string TypeName { get; set; }
        public string Dietary { get; set; }
        public override string ToString() => $"[{RecipeID}] {RecipeTitle}";
       
    }
}
