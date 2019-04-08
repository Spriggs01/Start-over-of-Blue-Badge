using HealthyEats.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealtyEats.Models
{
    public class MealDetail
    {
        public int MealID { get; set; }
        public string MealName { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
        public override string ToString() => $"[{MealID}] {MealName}";
    }
}
