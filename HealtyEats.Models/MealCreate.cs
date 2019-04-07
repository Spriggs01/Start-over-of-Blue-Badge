﻿using HealthyEats.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealtyEats.Models
{
    public class MealCreate
    {

        public string MealDescription { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }



    }
}
