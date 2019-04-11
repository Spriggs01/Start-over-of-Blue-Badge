﻿using HealthyEats.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealtyEats.Models
{
    public class MealListItem
    {
        public int MealID { get; set; }

        public int RecipeID { get; set; }

        [Key]
        public string MealName { get; set; }

        public string MealDescription { get; set; }


        public override string ToString() => MealName;
        
    }
}
