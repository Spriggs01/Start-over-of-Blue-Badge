﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyEats.WebMVC.Data
{
    public class FavoriteRecipe
    {
       
        [Required]
        public Guid UserID { get; set; }

        [Key]
        public int RecipeID { get; set; }
    }
}
