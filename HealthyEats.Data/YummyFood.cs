using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyEats.Data
{
   public class YummyFood
    {
        public Guid UserID { get; set; }

        public int MealID { get; set; }

        public int RecipeID { get; set; }
    }
}
