﻿using HealthyEats.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealtyEats.Models
{
    public class MealListItem
    {
        public int MealID { get; set; }

        public string MealDescription { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }


    }
}