﻿using HealthyEats.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealtyEats.Models
{
    public class MealCreate
    {
        
      

        [Display(Name = "Meal Name")]
        public string MealName { get; set; }

        [Display(Name = "Meal Description")]
        public string MealDescription { get; set; }

        [Display(Name = "Recipe Title")]
        public int RecipeID { get; set; }

        public override string ToString() => MealName;
    }
}
