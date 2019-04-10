using HealthyEats.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealtyEats.Models
{
    public class MealEdit
    {
        public int MealID { get; set; }

        public string MealName { get; set; }

        public string MealDescription { get; set; }

        public override string ToString() => $"[{MealID}] {MealName}";
    }
}
